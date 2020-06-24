﻿using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Parametros_Usuario
	{
		private int _idUsuario;

		public Comando_Parametros_Usuario()
		{

		}

		public Comando_Parametros_Usuario(int UsuarioId)
		{
			this._idUsuario = UsuarioId;
		}

		async public Task<List<ComUsuarioParametro>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.CrearDaoBase();
			return dao.ParametrosUsuario(this._idUsuario);
		}
		
		
	}
}