﻿using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
	public class Comando_Reintegro_Cuenta
	{
		private int _idUsuarioReceptor { get; set; }
		private int _idMedioPaga { get; set; }
		private double _monto { get; set; }
		private int _idOperacion { get; set; }

		public Comando_Reintegro_Cuenta(int IdUsuarioReceptor, int IdMedioPaga,double Monto, int IdOperacion)
		{
			this._idUsuarioReceptor = IdUsuarioReceptor;
			this._idMedioPaga = IdMedioPaga;
			this._monto = Monto;
			this._idOperacion = IdOperacion;
		}

		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = new DAOBase();
			dao.ReintegroCuenta(_idUsuarioReceptor, _idMedioPaga, _monto, _idOperacion);
			return true;
		}
	}
}
