using Comandos;
using Excepciones.Excepciones_Especificas;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Entities;
using moneyucab_portalweb_back.Models;
using System;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Verificar_Registro_Usuario : Comando<Object>
    {

        private UserManager<Usuario> _userManager;
        private RegistrationModel _userModel;

        public Comando_Verificar_Registro_Usuario(UserManager<Usuario> userManager, RegistrationModel userModel)
        {
            this._userManager = userManager;
            this._userModel = userModel;
        }

        async public Task<Object> Ejecutar()
        {

            // Chequeo que el username no este registrado
            try
            {
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, _userModel.UserName, _userModel.Email, null).Ejecutar();
            }
            catch (UsuarioExistenteException ex)
            {
                if (ex.Codigo == 11)
                {
                    //Se captura si no existe previamente el usuario.
                    //Se debe ingresar en este punto la validación DAO con el sistema propio y no con Identity

                    //-------------------------------------------------------
                }
                else
                    UsuarioExistenteException.UsuarioExistente();
            }
            return null;
        }
    }
}
