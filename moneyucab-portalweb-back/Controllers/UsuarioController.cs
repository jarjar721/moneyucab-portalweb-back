using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using moneyucab_portalweb_back.Email;
using moneyucab_portalweb_back.Models;
using moneyucab_portalweb_back.Models.Entities;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private readonly ApplicationSettings _appSettings;
        private IEmailSender _emailSender; 

        public UsuarioController(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            IOptions<ApplicationSettings> appSettings,
            IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("Register")]
        //Post : /api/Usuario/Register
        public async Task<Object> Register(RegistrationModel userModel)
        {
            // Se crea el objeto del usuario a registrar
            var usuario = new Usuario()
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                SignupDate = DateTime.Now
            };

            try
            {
                // Se crea el usuario en la base de datos
                var result = await _userManager.CreateAsync(usuario, userModel.Password);

                // Se genera el codigo para confirmar el email del usuario recien creado
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                // Busco el ID del template que será usado en el correo a enviar.
                var templateID = _appSettings.ConfirmAccountTemplateID;
                // Se crea el link que será anexado al template del correo
                var callbackURL = Url.Action("ConfirmEmail", "Usuario", new { UserId = usuario.Id, Code = code }, protocol: HttpContext.Request.Scheme);

                // Se envía el mensaje al correo del usuario registrado
                await _emailSender.SendEmailAsync(templateID, usuario.Email, usuario.UserName, "MoneyUCAB - Confirma tu correo electrónico", callbackURL);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost]
        [Route("Login")]
        //Post : /api/Usuario/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Busco el usuario en la base de datos - Get user in database
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {

                // Generar un nuevo token - Generate a new token
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id.ToString()),
                        new Claim("LoggedOn", DateTime.Now.ToString())
                        //Aqui se agrega el rol o roles que tiene el usuario que inicia sesion
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_appSettings.Token_ExpiredTime)), // El token expira luego de este tiempo
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new { token });

            }
            else
            {
                return BadRequest(new { message = "¡Email o contraseña incorrecta!" });
            }

        }


        [HttpGet]
        [Route("ConfirmedEmail")]
        [AllowAnonymous]
        //Get : /api/Usuario/ConfirmedEmail
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            // Reviso que los parametros no sean nulos o con errores
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            //Busco al usuario por su ID
            var usuario = await _userManager.FindByIdAsync(userId);

            if (usuario == null) // Si el usuario no está en la BD
            {
                return new JsonResult("ERROR: User Id not found");
            }
            if (usuario.EmailConfirmed) //Si ya es un usuario con email confirmado
            {
                return Redirect("/login");
            }

            // Cambia en la BD el "ConfirmEmail" a TRUE
            var result = await _userManager.ConfirmEmailAsync(usuario, code);

            if (result.Succeeded)
            {
                return Ok(new { userId, code });
            }
            else
            {
                return BadRequest(new { message = "¡No se pude confimar el email del usuario!" });
            }

        }
    }
}