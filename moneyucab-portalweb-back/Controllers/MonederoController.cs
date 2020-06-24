using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.Entities;
using Microsoft.AspNetCore.Cors;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")] // api/saldo
    [EnableCors("Policy")]
    [ApiController]
    public class MonederoController : ControllerBase
    {
        [HttpGet] // api/Saldo/consultar
        [Route("Consultar")]
        public async Task<Object> Consultar([FromQuery]int UsuarioId) //No estoy claro de si aca se usa [frombody] o [fromform]
        {
            try
            {
                return Ok(await FabricaComandos.Fabricar_Cmd_Verificar_Saldo(UsuarioId).Ejecutar());
            }
            catch (Exception error)
            {
                var resultado = false;
                return BadRequest(resultado);
            }
        }
    }
}