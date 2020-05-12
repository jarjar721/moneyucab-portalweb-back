﻿using System;
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
                return Redirect("/login"); // Look into this!
            }

            // Cambia en la BD el "ConfirmEmail" a TRUE
            var result = await _userManager.ConfirmEmailAsync(usuario, code);

            if (result.Succeeded)
            {
                return Ok(new { userId, code });
            }
            else
            {
                return BadRequest(new { message = "¡No se pudo confimar el email del usuario!" });
            }

        }

        [HttpPost]
        [Route("ForgotPasswordEmail")]
        //Post : /api/Usuario/ForgotPasswordEmail
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

                return Ok(new { message = "¡Email enviado!", URL = callbackURL });
            } 
            else
            {
                return BadRequest(new { message = "El email no fue enviado. ¡Ocurrió un error!" });
            }

        }


        [HttpPost]
        [Route("ResetPassword")]
        //Post : /api/Usuario/ResetPassword
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            // Reviso que los parametros no sean nulos o con errores
            if (string.IsNullOrWhiteSpace(model.UserID) || string.IsNullOrWhiteSpace(model.ResetPasswordToken))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            // Busco al usuario por su ID
            var usuario = await _userManager.FindByIdAsync(model.UserID);

            if (usuario == null) // Si el usuario no está en la BD
            {
                return new JsonResult("ERROR: User Id not found");
            }

            // Decodificando el token
            var decodedToken = model.ResetPasswordToken.Replace("_", "/").Replace("-", "+").Replace(".", "=");

            // Cambia la contraseña del usuario
            var result = await _userManager.ResetPasswordAsync(usuario, decodedToken, model.NewPassword);

            if (result.Succeeded)
            {
                return Ok(new { message = "¡Contraseña restablecida!" });
            }
            else
            {
                return BadRequest(new { message = "¡No se pudo restablecer la contraseña del usuario!" });
            }

        }

    }
}