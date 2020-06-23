using Excepciones;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.Models;
using moneyucab_portalweb_back.EntitiesForm;
using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private readonly ApplicationSettings _appSettings;
        private IEmailSender _emailSender;

        private readonly string clientBaseURI = "http://localhost:4200/#/";

        public AuthenticationController(
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
        //Post: /api/Authentication/Register
        public async Task<Object> Register(RegistrationModel userModel)
        {
            try
            {
                //Ejecución de comandos para funcionalidad de registro

                // Chequeo que el username no este registrado
                await FabricaComandos.Fabricar_Cmd_Verificar_Registro_Usuario(this._userManager, userModel).Ejecutar();
                //Se realiza el registro del usuario
                var result = await FabricaComandos.Fabricar_Cmd_Registro_Usuario(_userManager, userModel, _appSettings, _emailSender).Ejecutar();

                return Ok(result);
            }
            catch (MoneyUcabException ex)
            {
                //Debe controlarse un error dentro de la plataforma
                //Se realiza bad request respondiendo con el objeto obtenido
                return BadRequest(ex.response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.response_error_desconocido(ex));
            }
        }


        [HttpPost]
        [Route("Login")]
        //Post: /api/Authentication/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                // Busco el usuario en la base de datos - Get user in database
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, model.Email, model.Email, null).Ejecutar();
                // await FabricaComandos.Fabricar_Cmd_Verificar_Email_Confirmado(model.Email, _userManager).Ejecutar();
                // Obtengo el resultado de iniciar sesión 
                var result = await FabricaComandos.Fabricar_Cmd_Inicio_Sesion(_userManager, model, _appSettings, _signInManager).Ejecutar();
                return Ok(result);
            }
            catch (MoneyUcabException ex)
            {
                //Se retorna el badRequest con los datos de la excepción
                return BadRequest(ex.response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.response_error_desconocido(ex));
            }
        }


        [HttpPost]
        [Route("ConfirmedEmail")]
        //[AllowAnonymous]
        //Post: /api/Authentication/ConfirmedEmail
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
            catch (MoneyUcabException ex)
            {
                //Error al intentar confirmar el email.
                return BadRequest(ex.response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.response_error_desconocido(ex));
            }

        }


        [HttpPost]
        [Route("ForgotPasswordEmail")]
        //Post: /api/Authentication/ForgotPasswordEmail
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
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.response_error_desconocido(ex));
            }

        }


        [HttpPost]
        [Route("ResetPassword")]
        //Post: /api/Authentication/ResetPassword
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
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.response_error_desconocido(ex));
            }

        }

        [HttpPost]
        [Authorize]
        [Route("Modification")]
        public async Task<IActionResult> Modification([FromBody]ModificacionUsuario formulario)
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Modificar_Usuario(formulario.usuario, formulario.email, formulario.telefono, formulario.direccion, formulario.IdUsuario).Ejecutar());
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.response_error_desconocido(ex));
            }

        }


    }
}