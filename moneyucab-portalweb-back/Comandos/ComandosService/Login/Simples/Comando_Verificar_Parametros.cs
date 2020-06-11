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

        private string[] _parametros;

        public Comando_Verificar_Parametros(params string[] parametros)
        {
            this._parametros = parametros;
        }


        async public Task<Object> Ejecutar()
        {
            for (int i = 0; i < _parametros.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(_parametros[i]))
                {
                    //throw exception
                }
            }
            return null;
        }

    }
}
