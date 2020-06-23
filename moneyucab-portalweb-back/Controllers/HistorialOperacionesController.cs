using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunes.Comun;
using Excepciones;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.Entities;
using moneyucab_portalweb_back.Comandos;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialOperacionesController : ControllerBase
    {

        [HttpGet]
        [Authorize]
        [Route("HistorialOperacionesTarjeta")]
        //GET: /api/Dashboard/HistorialOperacionesTarjeta
        public async Task<Object> HistorialOperacionesTarjeta([FromQuery]int TarjetaId)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Hist_OpTarjeta(TarjetaId).Ejecutar());
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
        public async Task<Object> HistorialOperacionesCuenta([FromQuery] int CuentaId)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Hist_OpCuenta(CuentaId).Ejecutar());
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
        public async Task<Object> HistorialOperacionesMonedero([FromQuery] int UsuarioId)
        {

            try
            {

                return Ok(await FabricaComandos.Fabricar_Cmd_Hist_OpMonedero(UsuarioId).Ejecutar());
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