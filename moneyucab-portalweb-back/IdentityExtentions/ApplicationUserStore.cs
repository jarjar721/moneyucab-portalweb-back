using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using moneyucab_portalweb_back.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.IdentityExtentions
{
    public class ApplicationUserStore : UserManager<Usuario>
    {

        public ApplicationUserStore(
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

        public Task AddToPreviousPasswordsAsync(Usuario user, string password)
        {
            user.PreviousUserPasswords.Add(
                new PreviousPasswords() { 
                    UsuarioID = user.Id, 
                    PasswordHash = password 
                }
            );
            return UpdateAsync(user);
        }
    }
}
