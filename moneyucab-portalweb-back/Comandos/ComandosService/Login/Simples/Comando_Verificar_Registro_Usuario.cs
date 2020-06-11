using Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using moneyucab_portalweb_back.Models;
using moneyucab_portalweb_back.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.Models.FormModels;

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
                await FabricaComandos.Fabricar_Cmd_Existencia_Usuario(_userManager, _userModel).Ejecutar();
            }
            catch (Exception ex)
            {
                //Se captura si no existe previamente el usuario.
                //Se debe ingresar en este punto la validación DAO con el sistema propio y no con Identity

                //-------------------------------------------------------
            }

            return null;
        }
    }
}
