using Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogicController : ControllerBase
    {
        private UserManager<Usuario> _userManager;

        public LogicController(UserManager<Usuario> userManager)
        {
            _userManager = userManager;
        }

        //Operaciones de consulta---------------------------------------------------------------

        [HttpGet]
        [Authorize]
        [Route("EstadosCiviles")]
        //GET: /api/Dashboard/EstadosCiviles
        public async Task<Object> EstadosCiviles()
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("TiposTarjetas")]
        //GET: /api/Dashboard/TiposTarjetas
        public async Task<Object> TiposTarjeta()
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("Bancos")]
        //GET: /api/Dashboard/Bancos
        public async Task<Object> Bancos()
        {

            try
            {

                return Ok();
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


        [HttpGet]
        [Authorize]
        [Route("TiposCuentas")]
        //GET: /api/Dashboard/TiposCuentas
        public async Task<Object> TiposCuentas()
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("TiposParametros")]
        //GET: /api/Dashboard/TiposParametros
        public async Task<Object> TiposParametros()
        {

            try
            {

                return Ok();
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
        
        [HttpGet]
        [Authorize]
        [Route("Frecuencias")]
        //GET: /api/Dashboard/Frecuencias
        public async Task<Object> Frecuencias()
        {

            try
            {

                return Ok();
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
        
        [HttpGet]
        [Authorize]
        [Route("Parametros")]
        //GET: /api/Dashboard/Parametros
        public async Task<Object> Parametros()
        {

            try
            {

                return Ok();
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
        
        [HttpGet]
        [Authorize]
        [Route("TiposOperaciones")]
        //GET: /api/Dashboard/TiposOperaciones
        public async Task<Object> TiposOperaciones()
        {

            try
            {

                return Ok();
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
        
        [HttpGet]
        [Authorize]
        [Route("TiposIdentificaciones")]
        //GET: /api/Dashboard/TiposIdentificaciones
        public async Task<Object> TiposIdentificaciones()
        {

            try
            {

                return Ok();
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
        
        [HttpGet]
        [Authorize]
        [Route("Tarjetas")]
        //GET: /api/Dashboard/Tarjetas
        public async Task<Object> Tarjetas(int UsuarioId)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("Cuentas")]
        //GET: /api/Dashboard/Cuentas
        public async Task<Object> Cuentas(int UsuarioId)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("ReintegrosActivos")]
        //GET: /api/Dashboard/ReintegrosActivos
        public async Task<Object> ReintegrosActivos(int UsuarioId, int solicitante)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("ReintegrosCancelados")]
        //GET: /api/Dashboard/ReintegrosCancelados
        public async Task<Object> ReintegrosCancelados(int UsuarioId, int solicitante)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("ReintegrosExitosos")]
        //GET: /api/Dashboard/ReintegrosExitosos
        public async Task<Object> ReintegrosExitosos(int UsuarioId, int solicitante)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("CobrosActivos")]
        //GET: /api/Dashboard/CobrosActivos
        public async Task<Object> CobrosActivos(int UsuarioId, int solicitante)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("CobrosCancelados")]
        //GET: /api/Dashboard/CobrosCancelados
        public async Task<Object> CobrosCancelados(int UsuarioId, int solicitante)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("CobrosExitosos")]
        //GET: /api/Dashboard/CobrosExitosos
        public async Task<Object> CobrosExitosos(int UsuarioId, int solicitante)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("ParametrosUsuario")]
        //GET: /api/Dashboard/ParametrosUsuario
        public async Task<Object> ParametrosUsuario(int UsuarioId)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("InformacionPersona")]
        //GET: /api/Dashboard/InformacionPersona
        public async Task<Object> InformacionPersona(string usuario)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("SaldoMonedero")]
        //GET: /api/Dashboard/SaldoMonedero
        public async Task<Object> SaldoMonedero(int UsuarioId)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("HistorialOperacionesTarjeta")]
        //GET: /api/Dashboard/HistorialOperacionesTarjeta
        public async Task<Object> HistorialOperacionesTarjeta(int tarjetaId)
        {

            try
            {

                return Ok();
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
        
        [HttpGet]
        [Authorize]
        [Route("HistorialOperacionesCuenta")]
        //GET: /api/Dashboard/HistorialOperacionesCuenta
        public async Task<Object> HistorialOperacionesCuenta(int CuentaId)
        {

            try
            {

                return Ok();
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

        [HttpGet]
        [Authorize]
        [Route("HistorialOperacionesMonedero")]
        //GET: /api/Dashboard/HistorialOperacionesMonedero
        public async Task<Object> HistorialOperacionesMonedero(int UsuarioId)
        {

            try
            {

                return Ok();
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

    }
}