using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
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
using moneyucab_portalweb_back.Models.FormModels;

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

        private readonly string clientBaseURI = "http://localhost:4200/#/";

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
        //Post: /api/Usuario/Register
        public async Task<Object> Register(RegistrationModel userModel)
        {
            // Se crea el objeto del usuario a registrar
            var usuario = new Usuario()
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                SignupDate = DateTime.Now
            };

            // Chequeo que el username no este registrado
            if (await _userManager.FindByNameAsync(usuario.UserName) != null)
            {
                return BadRequest(new { key = "DuplicateUserName", message = "Intente ingresar un username distinto" });
            }
            // Chequeo que el email no este registrado
            if (await _userManager.FindByEmailAsync(usuario.Email) != null)
            {
                return BadRequest(new { key = "DuplicateEmail", message = "Intente ingresar un correo electrónico distinto" });
            }

            // Se crea el usuario en la base de datos
            var result = await _userManager.CreateAsync(usuario, userModel.Password);
            // Se genera el codigo para confirmar el email del usuario recien creado
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            // Se codifica el token para poder enviarlo por parametro
            var encodedToken = code.Replace("/", "_").Replace("+", "-").Replace("=", ".");
            // Busco el ID del template que será usado en el correo a enviar.
            var templateID = _appSettings.ConfirmAccountTemplateID;
            // Se crea el link que será anexado al template del correo
            var callbackURL = clientBaseURI + "account-confirmed/" + usuario.Id + "/" + encodedToken;

            // Se crea el mensaje con sus detalles para el envío
            var emailDetails = new SendEmailDetails 
            { 
                FromName = "MoneyUCAB",
                FromEmail = "moneyucab@gmail.com",
                ToName = usuario.UserName,
                ToEmail = usuario.Email,
                Subject = "MoneyUCAB - Confirma tu correo electrónico",
                TemplateID = templateID,
                TemplateData = new EmailData
                {
                    Name = usuario.UserName,
                    URL = callbackURL,
                    Message = "¡Nos emociona muchísimo tenerte en la familia! " +
                                "Para ello, es indispensable que confirmes tu cuenta para gozar de nuestros servicios. " +
                                "Solo haz click en el botón.",
                    ButtonTitle = "Confirmar cuenta"
                }
            };

            // Se envía el mensaje al correo del usuario registrado
            await _emailSender.SendEmailAsync(emailDetails);

            return Ok(result);

        }


        [HttpPost]
        [Route("Login")]
        //Post: /api/Usuario/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Busco el usuario en la base de datos - Get user in database
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest(new { key = "UnknownUser", message = "No existe un usuario registrado con ese email"});
            }

            // Obtengo el resultado de iniciar sesión 
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (result.Succeeded)
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

            if (result.IsLockedOut)
            {
                var lockoutDateTime = await _userManager.GetLockoutEndDateAsync(user); // Obtengo datetime de cuando se levanta la restriccion del lockout
                return BadRequest(new { key = "UserLockedOut", message = "Ha agotado sus intentos.", lockoutDateTime });
            }
            else
            {
                var remainingAttempts = 3 - await _userManager.GetAccessFailedCountAsync(user); // Obtengo la cantidad de intentos restantes le quedan al usuario
                return BadRequest(new { key = "WrongPassword", message = "Contraseña inválida", remainingAttempts });
            }

        }


        [HttpPost]
        [Route("ConfirmedEmail")]
        //[AllowAnonymous]
        //Post: /api/Usuario/ConfirmedEmail
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailModel model)
        {
            // Reviso que los parametros no sean nulos o con errores
            if (string.IsNullOrWhiteSpace(model.UserID) || string.IsNullOrWhiteSpace(model.ConfirmationToken))
            {
                return BadRequest(new { key = "EmptyFields", message = "No se recibieron parámetros"});
            }

            //Busco al usuario por su ID
            var usuario = await _userManager.FindByIdAsync(model.UserID);

            if (usuario == null) // Si el usuario no está en la BD
            {
                return BadRequest(new { key = "UnknownUser", message = "Usuario no encontrado"});
            }
            if (usuario.EmailConfirmed) //Si ya es un usuario con email confirmado
            {
                return BadRequest(new { key = "ConfirmedAccount", message = "La cuenta ya ha sido confirmada"});
            }

            // Decodificando el token
            var decodedToken = model.ConfirmationToken.Replace("_", "/").Replace("-", "+").Replace(".", "=");

            // Cambia en la BD el "ConfirmEmail" a TRUE
            var result = await _userManager.ConfirmEmailAsync(usuario, decodedToken);

            if (result.Succeeded)
            {
                return Ok(new { key = "AccountConfirmed", message = "Email confirmado por el usuario: " + usuario.UserName });
            }
            else
            {
                return BadRequest(new { key = "ConfirmationFailed", message = "¡No se pudo confimar el email del usuario!"});
            }

        }


        [HttpPost]
        [Route("ForgotPasswordEmail")]
        //Post: /api/Usuario/ForgotPasswordEmail
        public async Task<IActionResult> SendForgotPasswordEmail(ForgotPasswordModel model)
        {
            // Busco el usuario en la base de datos - Get user in database
            var usuario = await _userManager.FindByEmailAsync(model.Email);

            if (usuario != null) 
            {
                // Se genera el codigo para confirmar el email del usuario recien creado
                var code = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                // Se codifica el token para poder enviarlo por parametro
                var encodedToken = code.Replace("/", "_").Replace("+", "-").Replace("=", ".");
                // Busco el ID del template que será usado en el correo a enviar.
                var templateID = _appSettings.ConfirmAccountTemplateID;
                // Se crea el link que será anexado al template del correo
                var callbackURL = clientBaseURI + "pw-reset/" + usuario.Id + "/" + encodedToken;

                // Se crea el mensaje con sus detalles para el envío
                var emailDetails = new SendEmailDetails
                {
                    FromName = "MoneyUCAB",
                    FromEmail = "moneyucab@gmail.com",
                    ToName = usuario.UserName,
                    ToEmail = usuario.Email,
                    Subject = "MoneyUCAB - Restablece tu contraseña",
                    TemplateID = templateID,
                    TemplateData = new EmailData
                    {
                        Name = usuario.UserName,
                        URL = callbackURL,
                        Message = "¿Has olvidado tu contraseña? ¡No te preocupes! " +
                                  "Te enviamos este mensaje para que puedas restablecerla. " +
                                  "Solo debes hacer click en el botón.",
                        ButtonTitle = "Restablecer contraseña"
                    }
                };

                // Se envía el mensaje al correo del usuario registrado
                await _emailSender.SendEmailAsync(emailDetails);

                return Ok(new { key = "ForgotPasswordEmailSent", message = "Un mensaje ha sido enviado a su email con instrucciones para restablecer su contraseña" });
            } 
            else
            {
                return BadRequest(new { key = "ForgotPasswordEmailFailed", message = "El email no fue enviado." });
            }

        }


        [HttpPost]
        [Route("ResetPassword")]
        //Post: /api/Usuario/ResetPassword
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            // Reviso que los parametros no sean nulos o con errores
            if (string.IsNullOrWhiteSpace(model.UserID) || string.IsNullOrWhiteSpace(model.ResetPasswordToken))
            {
                return BadRequest(new { key = "EmptyFields", message = "No se recibieron parámetros"});
            }

            // Busco al usuario por su ID
            var usuario = await _userManager.FindByIdAsync(model.UserID);

            if (usuario == null) // Si el usuario no está en la BD
            {
                return BadRequest(new { key = "UnknownUser", message = "Usuario no encontrado"});
            }

            // Decodificando el token
            var decodedToken = model.ResetPasswordToken.Replace("_", "/").Replace("-", "+").Replace(".", "=");

            // Cambia la contraseña del usuario
            var result = await _userManager.ResetPasswordAsync(usuario, decodedToken, model.NewPassword);

            if (result.Succeeded)
            {
                return Ok(new { key = "ResetPasswordSuccess", message = "¡Contraseña restablecida!" });
            }
            else
            {
                return BadRequest(new { key = "ResetPasswordFailed", message = "¡No se pudo restablecer la contraseña del usuario!"});
            }

        }


    }
}