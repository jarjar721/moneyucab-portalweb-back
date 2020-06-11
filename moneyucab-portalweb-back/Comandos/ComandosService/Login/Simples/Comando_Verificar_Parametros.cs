using Comandos;
using moneyucab_portalweb_back.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Parametros: Comando<Object>
    {

        private ConfirmEmailModel _model;

        public Comando_Inicio_Sesion(ConfirmEmailModel userModel)
        {
            this._model = userModel;
        }


        async public Task<Object> Ejecutar()
        {

            if (string.IsNullOrWhiteSpace(_model.UserID) || string.IsNullOrWhiteSpace(_model.ConfirmationToken))
            {
                //throw exception
            }
            return null;
        }

    }
}
