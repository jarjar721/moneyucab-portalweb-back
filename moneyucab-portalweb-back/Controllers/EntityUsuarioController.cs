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

        public EntityUsuarioController(EntityDatosUsuario comandoDatosUsuario)
        {
            _comandoDatosUsuario = comandoDatosUsuario;
        }

        [HttpGet] // api/EntityUsuario/consultar
        [Route("Consultar")]
        public IActionResult Consultar()
        {
            try
            {
                var resultado = _comandoDatosUsuario.consultar();
                return Ok(resultado);
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

        [HttpPost] //api/EntityUsuario/insertar
        [Route("Insertar")]
        public IActionResult Agregar([FromBody] DatosUsuario _datosUsuario)
        {
            try {
                var resultado = _comandoDatosUsuario.insertar(_datosUsuario);
                return Ok(resultado);
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

        [HttpPut] //api/EntityUsuario/editar
        [Route("Editar")]
        public IActionResult Editar([FromBody] DatosUsuario _datosUsuario)
        {
            try
            {
                var resultado = _comandoDatosUsuario.Editar(_datosUsuario);
                return Ok(resultado);
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

        [HttpDelete]  // api/EntityUsuario/eliminar/5
        [Route("eliminar/{UsuarioID}")]
        public IActionResult Eliminar(int UsuarioID) //NoticiaID igual qeu ene el route
        {
            try{
                var resultado = _comandoDatosUsuario.Eliminar(UsuarioID);
                return Ok(resultado);
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