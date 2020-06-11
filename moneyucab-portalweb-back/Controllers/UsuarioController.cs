using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Comandos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.Entities;
using moneyucab_portalweb_back.Models;
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
            try
            {
                //Ejecución de comandos para funcionalidad de registro

                // Chequeo que el username no este registrado
                await FabricaComandos.Fabricar_Cmd_Verificar_Registro_Usuario(this._userManager, userModel).Ejecutar();
                //Se realiza el registro del usuario
                var result = FabricaComandos.Fabricar_Cmd_Registro_Usuario(_userManager, userModel, _appSettings, _emailSender).Ejecutar();

                return Ok(result);
            }
            catch (Exception ex)
            {
                //Debe controlarse un error dentro de la plataforma
                //Se realiza bad request respondiendo con el objeto obtenido
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("Login")]
        //Post: /api/Usuario/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                // Busco el usuario en la base de datos - Get user in database
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, model.Email, model.Email, null).Ejecutar();

                // Obtengo el resultado de iniciar sesión 
                var result = await FabricaComandos.Fabricar_Cmd_Inicio_Sesion(_userManager, model, _appSettings).Ejecutar();
                return Ok(result);
            }
            catch (Exception ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("ConfirmedEmail")]
        //[AllowAnonymous]
        //Post: /api/Usuario/ConfirmedEmail
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailModel model)
        {
            try
            {
                // Reviso que los parametros no sean nulos o con errores
                await FabricaComandos.Fabricar_Cmd_Verificar_Parametros(model.ConfirmationToken, model.UserID).Ejecutar();

                //Busco al usuario por su ID

                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, null, null, model.UserID).Ejecutar();
                await FabricaComandos.Fabricar_Cmd_Confirmar_Email(model.UserID, _userManager, model).Ejecutar();
                //Se responde positivamente por el proceso.
                return Ok();
            }
            catch(Exception ex)
            {
                //Error al intentar confirmar el email.
                return BadRequest(ex);
            }

        }


        [HttpPost]
        [Route("ForgotPasswordEmail")]
        //Post: /api/Usuario/ForgotPasswordEmail
        public async Task<IActionResult> SendForgotPasswordEmail(ForgotPasswordModel model)
        {
            try
            {
                // Busco el usuario en la base de datos - Get user in database
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, model.Email, model.Email, null).Ejecutar();
                //Proceso de envío y recuperación de contraseña.    
                await FabricaComandos.Fabricar_Cmd_Olvido_Contraseña(_userManager, model, _appSettings, _emailSender).Ejecutar();
                return Ok(new { key = "ForgotPasswordEmailSent", message = "Un mensaje ha sido enviado a su email con instrucciones para restablecer su contraseña" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

        }


        [HttpPost]
        [Route("ResetPassword")]
        //Post: /api/Usuario/ResetPassword
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            try
            {
                // Reviso que los parametros no sean nulos o con errores
                await FabricaComandos.Fabricar_Cmd_Verificar_Parametros(model.NewPassword, model.ResetPasswordToken).Ejecutar();

                // Busco al usuario por su ID
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, null, null, model.UserID).Ejecutar();
                await FabricaComandos.Fabricar_Cmd_Resetear_Password(_userManager, model).Ejecutar();

                return Ok(new { key = "ResetPasswordSuccess", message = "¡Contraseña restablecida!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


    }
}