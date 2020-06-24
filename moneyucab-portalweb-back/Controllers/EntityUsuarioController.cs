using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.EntitiesForm;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]  //api/datosusuario
    [ApiController]
    public class EntityUsuarioController : ControllerBase
    {
        private readonly EntityDatosUsuario _comandoDatosUsuario;

        public EntityUsuarioController(EntityDatosUsuario ComandoDatosUsuario)
        {
            _comandoDatosUsuario = ComandoDatosUsuario;
        }

        [HttpGet] // api/DatosUsuario/consultar
        [Route("Consultar")]
        public IActionResult Consultar()
        {
            try
            {
                var resultado = _comandoDatosUsuario.Consultar();
                return Ok(resultado);
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpPost] //api/DatosUsuario/insertar
        [Route("Insertar")]
        public IActionResult Agregar([FromBody] DatosUsuario DatosUsuario)
        {
            try {
                var resultado = _comandoDatosUsuario.Insertar(DatosUsuario);
                return Ok(resultado);
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }

        }

        [HttpPut] //api/DatosUsuario/editar
        [Route("Editar")]
        public IActionResult Editar([FromBody] DatosUsuario DatosUsuario)
        {
            try
            {
                var resultado = _comandoDatosUsuario.Editar(DatosUsuario);
                return Ok(resultado);
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpDelete]  // api/DatosUsuario/eliminar/5
        [Route("eliminar/{IdUsuario}")]
        public IActionResult Eliminar(int IdUsuario) //NoticiaID igual qeu ene el route
        {
            try{
                var resultado = _comandoDatosUsuario.Eliminar(IdUsuario);
                return Ok(resultado);
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }
    }
}