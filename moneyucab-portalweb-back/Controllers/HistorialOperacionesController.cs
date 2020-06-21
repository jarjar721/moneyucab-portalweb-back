using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunes.Comun;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades;
using moneyucab_portalweb_back.Entities;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialOperacionesController : ControllerBase
    {
		[HttpGet]
		public IActionResult Consultar([FromBody] OperacionMonedero operacionMonedero)
		{
			try
			{

				Comando_Verificar_Operacion comandoOperacionMonedero = new Comando_Verificar_Operacion(operacionMonedero.idUsuario);
				comandoOperacionMonedero.Ejecutar();

				List<ComOperacionMonedero> operaciones = new List<ComOperacionMonedero>();
				operaciones = comandoOperacionMonedero.operaciones;

				var resultado = operaciones;

				return Ok(operaciones);
			}
			catch (Exception error)
			{
				var resultado = false;
				return BadRequest(resultado);
			}
		}
	}
}