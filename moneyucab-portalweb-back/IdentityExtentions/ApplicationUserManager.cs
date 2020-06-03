using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using moneyucab_portalweb_back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.IdentityExtentions
{
    public class ApplicationUserManager : UserManager<Usuario>
    {
        private const int PASSWORD_HISTORY_LIMIT = 3;

        public ApplicationUserManager(
            IUserStore<Usuario> store,
            IOptions<IdentityOptions> optionsAccesor,
            IPasswordHasher<Usuario> passwordHasher,
            IEnumerable<IUserValidator<Usuario>> userValidators,
            IEnumerable<IPasswordValidator<Usuario>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<Usuario>> logger
            ) : base(
                store, optionsAccesor, passwordHasher, userValidators,
                passwordValidators, keyNormalizer, errors, services, logger
                )
        {
        }

        public override async Task<IdentityResult> CreateAsync(Usuario user, string password)
        {
            await base.CreateAsync(user, password);
            await AddToPreviousPasswordsAsync(user, password);
            return await Task.FromResult(IdentityResult.Success);
        }

        public override async Task<IdentityResult> ChangePasswordAsync(Usuario user, string currentPassword, string newPassword)
        {
            if (await IsPreviousPassword(user.Id, newPassword))
            {
                return await Task.FromResult(IdentityResult.Failed());
            }
            var result = await base.ChangePasswordAsync(user, currentPassword, newPassword);
            if (result.Succeeded)
            {
                await AddToPreviousPasswordsAsync(await FindByIdAsync(user.Id), PasswordHasher.HashPassword(user, newPassword));
            }
            return result;
        }

        public override async Task<IdentityResult> ResetPasswordAsync(Usuario user, string token, string newPassword)
        {
            if (await IsPreviousPassword(user.Id, newPassword))
            {
                return await Task.FromResult(IdentityResult.Failed());
            }
            var result = await base.ResetPasswordAsync(user, token, newPassword);
            if (result.Succeeded)
            {
                await AddToPreviousPasswordsAsync(await FindByIdAsync(user.Id), PasswordHasher.HashPassword(user, newPassword));
            }
            return result;
        }

        public Task AddToPreviousPasswordsAsync(Usuario user, string password)
        {
            user.PreviousUserPasswords.Add(
                new PreviousPasswords()
                {
                    UsuarioID = user.Id,
                    PasswordHash = password
                }
            );
            return UpdateAsync(user);
        }

        private async Task<bool> IsPreviousPassword(string userId, string newPassword)
        {
            var user = await FindByIdAsync(userId);
            var hashedPassword = user.PasswordHash;
            if (
                user.PreviousUserPasswords
                .OrderByDescending(x => x.FechaCreacion)
                .Select(x => x.PasswordHash)
                .Take(PASSWORD_HISTORY_LIMIT)
                .Where(x => PasswordHasher.VerifyHashedPassword(user, hashedPassword, newPassword) != PasswordVerificationResult.Failed)
                .Any()
            )
            {
                return true;
            }
            return false;
        }
    }
}
