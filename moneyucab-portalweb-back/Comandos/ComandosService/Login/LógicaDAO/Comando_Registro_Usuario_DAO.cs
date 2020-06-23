using Comunes.Comun;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using moneyucab_portalweb_back.EntitiesForm;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.LogicaDAO
{
	public class Comando_Registro_Usuario_DAO
	{
		private RegistrationModel formulario;

		public Comando_Registro_Usuario_DAO(RegistrationModel formulario)
		{
			this.formulario = formulario;
		}
		async public Task<Boolean> Ejecutar()
		{
			DAOBase dao = FabricaDAO.crearDaoBase();
			if (this.formulario.comercio)
            {
				dao.RegistroUsuarioComercio(this.formulario.Formatear_Formulario());
				return true;
            }
            else
            {
				dao.RegistroUsuarioPersona(this.formulario.Formatear_Formulario());
				return true;
			}
		}
		
		
	}
}
