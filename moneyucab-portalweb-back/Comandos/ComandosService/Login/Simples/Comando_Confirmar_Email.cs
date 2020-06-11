﻿using Comandos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using moneyucab_portalweb_back.Entities;
using moneyucab_portalweb_back.Models.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Confirmar_Email: Comando<Boolean>
    {
        private string UserId;
        private UserManager<Usuario> _userManager;
        private ConfirmEmailModel model;

        public Comando_Confirmar_Email(string UserId, UserManager<Usuario> userManager, ConfirmEmailModel model)
        {
            this.UserId = UserId;
            this._userManager = userManager;
            this.model = model;
        }

        async public Task<Boolean> Ejecutar()
        {
            var usuario = await _userManager.FindByIdAsync(UserId);
            if (usuario.EmailConfirmed) //Si ya es un usuario con email confirmado
            {
                //Throw Exception
                //return BadRequest(new { key = "ConfirmedAccount", message = "La cuenta ya ha sido confirmada" });
            }

            // Decodificando el token
            var decodedToken = model.ConfirmationToken.Replace("_", "/").Replace("-", "+").Replace(".", "=");

            // Cambia en la BD el "ConfirmEmail" a TRUE
            var result = await _userManager.ConfirmEmailAsync(usuario, decodedToken);

            if (result.Succeeded)
            {
                return true;
            }
            else
            {   //Throw Exception
                //return BadRequest(new { key = "ConfirmationFailed", message = "¡No se pudo confimar el email del usuario!" });
            }
            return false;
        }
    }
}
