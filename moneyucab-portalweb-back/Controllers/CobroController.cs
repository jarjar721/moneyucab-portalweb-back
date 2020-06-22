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
    public class CobroController : ControllerBase
    {
        [HttpPost]
        [Route("RealizarCobro")]
        public IActionResult Cuenta([FromBody]Cobro cobro) //No estoy claro de si aca se usa [frombody] o [fromform]
        {


            try
            {
                Comando_Realizar_Cobro comando_Realizar_Cobro = new Comando_Realizar_Cobro(cobro.idUsuarioSolicitante, cobro.emailPagador, cobro.monto);
                comando_Realizar_Cobro.Ejecutar();
                var resultado = comando_Realizar_Cobro.cobroRealizado;

                return Ok(resultado);

            }
            catch (Exception error)
            {
                return BadRequest(false);
            }


        }
    }
}