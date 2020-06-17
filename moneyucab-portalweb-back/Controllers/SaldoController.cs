using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Entities;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")] // api/saldo
    [ApiController]
    public class SaldoController : ControllerBase
    {
        [HttpGet] // api/Saldo/consultar
        [Route("Consultar")]
        public IActionResult Consultar([FromBody]Saldo saldo) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            
            
            try
            {
                
                Comando_Verificar_Saldo comandoSaldo = new Comando_Verificar_Saldo(saldo.idUsuario);
                comandoSaldo.Ejecutar();
                saldo.saldoEnCuenta = comandoSaldo.saldoActual;
               
                var resultado = saldo;
                
                return Ok(resultado);
            }
            catch (Exception error)
            {
                var resultado = false;
                return BadRequest(resultado);
            }

            
        }
    }
}