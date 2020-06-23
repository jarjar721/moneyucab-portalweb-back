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

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilleteraController : ControllerBase
    {
        [HttpPost] // api/Billetera/cuenta
        [Route("Cuenta")]
        public async Task<IActionResult> CuentaAsync([FromBody]BilleteraCuenta billeteraCuenta) //No estoy claro de si aca se usa [frombody] o [fromform]
        {


            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Registrar_Cuenta(billeteraCuenta.idUsuario, billeteraCuenta.idTipoCuenta, billeteraCuenta.idBanco, billeteraCuenta.numero).Ejecutar());

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

        [HttpPost] // api/Billetera/tarjeta
        [Route("tarjeta")]
        public async Task<IActionResult> TarjetaAsync([FromBody]BilleteraTarjeta billeteraTarjeta) //No estoy claro de si aca se usa [frombody] o [fromform]
        {


            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Registrar_Tarjeta(billeteraTarjeta.idUsuario, billeteraTarjeta.idTipoTarjeta, billeteraTarjeta.idBanco,
                    billeteraTarjeta.numero, billeteraTarjeta.fecha_vencimiento, billeteraTarjeta.cvc, billeteraTarjeta.estatus).Ejecutar());
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

        //Comando inválido por los momentos
        [HttpDelete] // api/Billetera/eliminarcuenta
        [Route("EliminarCuenta")]
        public async Task<IActionResult> EliminarCuentaAsync([FromQuery]int CuentaId)
        {


            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Eliminar_Cuenta(CuentaId).Ejecutar());

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

        [HttpDelete] // api/Billetera/eliminartarjeta
        [Route("EliminarTarjeta")]
        public async Task<IActionResult> EliminarTarjetaAsync([FromQuery]int TarjetaId)
        {


            try
            {
                return Ok( await FabricaComandos.Fabricar_Cmd_Eliminar_Tarjeta(TarjetaId).Ejecutar());
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