using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades;
using moneyucab_portalweb_back.Entities;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilleteraController : ControllerBase
    {
        [HttpPost] // api/Billetera/cuenta
        [Route("Cuenta")]
        public IActionResult Cuenta([FromBody]BilleteraCuenta billeteraCuenta) //No estoy claro de si aca se usa [frombody] o [fromform]
        {


            try
            {
                Comando_Registrar_Billetera_Cuenta comando_Registrar_Billetera_Cuenta = new Comando_Registrar_Billetera_Cuenta(billeteraCuenta.idUsuario,billeteraCuenta.idTipoCuenta,billeteraCuenta.idBanco,billeteraCuenta.numero);
                var resultado = comando_Registrar_Billetera_Cuenta.Ejecutar();
                return Ok(resultado);
                
            }
            catch (Exception error)
            {
                return BadRequest(false);
            }


        }

        [HttpPost] // api/Billetera/tarjeta
        [Route("tarjeta")]
        public IActionResult Tarjeta([FromBody]BilleteraTarjeta billeteraTarjeta) //No estoy claro de si aca se usa [frombody] o [fromform]
        {


            try
            {

                Comando_Registrar_Billetera_Tarjeta comando_Registrar_Billetera_Tarjeta = new Comando_Registrar_Billetera_Tarjeta(billeteraTarjeta.idUsuario, billeteraTarjeta.idTipoTarjeta, billeteraTarjeta.idBanco, billeteraTarjeta.numero, billeteraTarjeta.cvc, billeteraTarjeta.estatus);
                var resultado = comando_Registrar_Billetera_Tarjeta.Ejecutar();
                return Ok(resultado);
            }
            catch (Exception error)
            {
                return BadRequest(false);
            }


        }

        [HttpDelete] // api/Billetera/eliminarcuenta
        [Route("EliminarCuenta")]
        public IActionResult EliminarCuenta([FromBody]BilleteraCuenta billeteraCuenta) //No estoy claro de si aca se usa [frombody] o [fromform]
        {


            try
            {
                Comando_Eliminar_Billetera_Cuenta comando_Eliminar_Billetera_Cuenta = new Comando_Eliminar_Billetera_Cuenta(billeteraCuenta.idUsuario, billeteraCuenta.idTipoCuenta, billeteraCuenta.idBanco, billeteraCuenta.numero);
                comando_Eliminar_Billetera_Cuenta.Ejecutar();
                var resultado = comando_Eliminar_Billetera_Cuenta.eliminacionCorrecta;
                return Ok(resultado);

            }
            catch (Exception error)
            {
                return BadRequest(false);
            }


        }

        [HttpDelete] // api/Billetera/eliminartarjeta
        [Route("EliminarTarjeta")]
        public IActionResult EliminarTarjeta([FromBody]BilleteraTarjeta billeteraTarjeta) //No estoy claro de si aca se usa [frombody] o [fromform]
        {


            try
            {
                Comando_Eliminar_Billetera_Tarjeta comando_Eliminar_Billetera_Tarjeta = new Comando_Eliminar_Billetera_Tarjeta(billeteraTarjeta.idUsuario, billeteraTarjeta.idTipoTarjeta, billeteraTarjeta.idBanco, billeteraTarjeta.numero, billeteraTarjeta.cvc, billeteraTarjeta.estatus);
                comando_Eliminar_Billetera_Tarjeta.Ejecutar();
                var resultado = comando_Eliminar_Billetera_Tarjeta.eliminacionCorrecta;
                return Ok(resultado);
            }
            catch (Exception error)
            {
                return BadRequest(false);
            }


        }
    }
}