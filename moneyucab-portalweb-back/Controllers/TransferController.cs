using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Comandos;
using Excepciones;
using Microsoft.AspNetCore.Authorization;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("RealizarCobro")]
        public async Task<Object> RealizarCobro([FromBody]Cobro cobro) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Realizar_Cobro(cobro.idUsuarioSolicitante, cobro.emailPagador, cobro.monto).Ejecutar());

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
        [Route("SolicitarReintegro")]
        public async Task<Object> SolicitarReintegro([FromBody] Reintegro reintegro) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Solicitar_Reintegro(reintegro.idUsuarioSolicitante, reintegro.emailPagador, reintegro.referencia).Ejecutar());

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
        [Route("CancelarCobro")]
        public async Task<Object> CancelarCobro([FromBody] int IdCobro) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Cancelar_Cobro(IdCobro).Ejecutar());

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
        [Route("CancelarReintegro")]
        public async Task<Object> CancelarReintegro([FromQuery] int IdReintegro) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Cancelar_Reintegro(IdReintegro).Ejecutar());

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
        [Route("RealizarPagoCuenta")]
        public async Task<Object> Realizar_Pago_Cuenta([FromBody] Transferencia formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Pago_Cuenta(formulario.idUsuarioReceptor, formulario.idMedioPaga, formulario.monto, formulario.idOperacion).Ejecutar());

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
        [Route("RealizarPagoTarjeta")]
        public async Task<Object> Realizar_Pago_Tarjeta([FromBody] Transferencia formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Pago_Tarjeta(formulario.idUsuarioReceptor, formulario.idMedioPaga, formulario.monto, formulario.idOperacion).Ejecutar());

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
        [Route("RealizarPagoMonedero")]
        public async Task<Object> Realizar_Pago_Monedero([FromBody] Transferencia formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Pago_Monedero(formulario.idUsuarioReceptor, formulario.idMedioPaga, formulario.monto, formulario.idOperacion).Ejecutar());

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
        [Route("RealizarReintegroCuenta")]
        public async Task<Object> Realizar_Reintegro_Cuenta([FromBody] Transferencia formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Reintegro_Cuenta(formulario.idUsuarioReceptor, formulario.idMedioPaga, formulario.monto, formulario.idOperacion).Ejecutar());

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
        [Route("RealizarReintegroTarjeta")]
        public async Task<Object> Realizar_Reintegro_Tarjeta([FromBody] Transferencia formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Reintegro_Tarjeta(formulario.idUsuarioReceptor, formulario.idMedioPaga, formulario.monto, formulario.idOperacion).Ejecutar());

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
        [Route("RealizarPagoMonedero")]
        public async Task<Object> Realizar_Reintegro_Monedero([FromBody] Transferencia formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Reintegro_Monedero(formulario.idUsuarioReceptor, formulario.idMedioPaga, formulario.monto, formulario.idOperacion).Ejecutar());

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
        [Route("EstablecerParametro")]
        public async Task<Object> Establecer_Parametro([FromBody] EstParametro formulario) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Establecer_Parametro(formulario.UsuarioId, formulario.ParametroId, formulario.validacion, formulario.estatus).Ejecutar());

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