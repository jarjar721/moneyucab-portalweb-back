﻿using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO
{
	public class Comando_Tipos_Tarjetas
	{

		public Comando_Tipos_Tarjetas()
		{

		}
		async public Task<List<ComTipoTarjeta>> Ejecutar()
		{
			DAOBase dao = FabricaDAO.crearDaoBase();
			return dao.TiposTarjeta();
		}
		
		
	}
}
