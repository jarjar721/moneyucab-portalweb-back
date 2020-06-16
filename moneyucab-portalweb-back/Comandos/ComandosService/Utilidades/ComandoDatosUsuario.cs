using moneyucab_portalweb_back.Contextos;
using moneyucab_portalweb_back.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Utilidades
{
	public class ComandoDatosUsuario
	{
		private readonly DatosUsuarioDBContext _datosUsuarioDBContext;
		public ComandoDatosUsuario(DatosUsuarioDBContext datosUsuarioDBContext)
		{
			_datosUsuarioDBContext = datosUsuarioDBContext;
		}
		
		public List<DatosUsuario> consultar()
		{
			var resultado = _datosUsuarioDBContext.DatosUsuario.ToList();
			return resultado;
		}

		public Boolean insertar(DatosUsuario _datosUsuario)
		{
			try
			{
				_datosUsuarioDBContext.DatosUsuario.Add(_datosUsuario);
				_datosUsuarioDBContext.SaveChanges();
				return true;
			}
			catch (Exception error)
			{
				return false;
			}
		}

		public Boolean Editar(DatosUsuario _datosUsuario)
		{
			try
			{
				var datosUsuarioBaseDeDatos = _datosUsuarioDBContext.DatosUsuario.Where(busqueda => busqueda.idUsuario == _datosUsuario.idUsuario).FirstOrDefault();

				datosUsuarioBaseDeDatos.usuario = _datosUsuario.usuario;
				datosUsuarioBaseDeDatos.nroIdentificacion = _datosUsuario.nroIdentificacion;
				datosUsuarioBaseDeDatos.email = _datosUsuario.email;
				datosUsuarioBaseDeDatos.telefono = _datosUsuario.telefono;
				datosUsuarioBaseDeDatos.direccion = _datosUsuario.direccion;
				_datosUsuarioDBContext.SaveChanges();

				return true;
			}
			catch(Exception error)
			{
				return false;
			}
		}

		public Boolean Eliminar(int usuarioID)
		{
			try
			{
				var usuarioBaseDeDatos = _datosUsuarioDBContext.DatosUsuario.Where(busqueda => busqueda.idUsuario == usuarioID).FirstOrDefault();
				_datosUsuarioDBContext.Remove(usuarioBaseDeDatos);

				_datosUsuarioDBContext.SaveChanges();

				return true;
			}
			catch(Exception error)
			{
				return false;
			}
		}

	}
}
