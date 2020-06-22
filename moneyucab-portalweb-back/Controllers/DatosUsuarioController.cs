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
    [Route("api/[controller]")]  //api/datosusuario
    [ApiController]
    public class DatosUsuarioController : ControllerBase
    {
        private readonly ComandoDatosUsuario _comandoDatosUsuario;

        public DatosUsuarioController(ComandoDatosUsuario comandoDatosUsuario)
        {
            _comandoDatosUsuario = comandoDatosUsuario;
        }

        [HttpGet] // api/DatosUsuario/consultar
        [Route("Consultar")]
        public IActionResult Consultar()
        {
            var resultado = _comandoDatosUsuario.consultar();
            return Ok(resultado);
        }

        [HttpPost] //api/DatosUsuario/insertar
        [Route("Insertar")]
        public IActionResult Agregar([FromBody] DatosUsuario _datosUsuario)
        {
            var resultado = _comandoDatosUsuario.insertar(_datosUsuario);
            if (resultado == true)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut] //api/DatosUsuario/editar
        [Route("Editar")]
        public IActionResult Editar([FromBody] DatosUsuario _datosUsuario)
        {
            var resultado = _comandoDatosUsuario.Editar(_datosUsuario);
            if (resultado == true)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete]  // api/DatosUsuario/eliminar/5
        [Route("eliminar/{UsuarioID}")]
        public IActionResult Eliminar(int UsuarioID) //NoticiaID igual qeu ene el route
        {
            {
                var resultado = _comandoDatosUsuario.Eliminar(UsuarioID);
                if (resultado == true)
                {
                    return Ok(resultado);
                }
                else
                {
                    return BadRequest();
                }

            }
        }



    }
}