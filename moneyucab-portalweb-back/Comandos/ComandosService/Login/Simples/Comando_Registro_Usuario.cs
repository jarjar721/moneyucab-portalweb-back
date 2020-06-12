﻿using Comandos;
using Microsoft.AspNetCore.Identity;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades.Email;
using moneyucab_portalweb_back.Entities;
using moneyucab_portalweb_back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples
{
    public class Comando_Registro_Usuario : Comando<Object>
    {

        private UserManager<Usuario> _userManager;
        private RegistrationModel _userModel;
        private readonly ApplicationSettings _appSettings;
        private IEmailSender _emailSender;

        private readonly string clientBaseURI = "http://localhost:4200/#/";

        public Comando_Registro_Usuario(UserManager<Usuario> userManager, RegistrationModel userModel, ApplicationSettings appSettings, IEmailSender _emailSender)
        {
            this._userManager = userManager;
            this._userModel = userModel;
            this._appSettings = appSettings;
            this._emailSender = _emailSender;
        }

        async public Task<Object> Ejecutar()
        {
            // Se crea el objeto del usuario a registrar
            var usuario = new Usuario()
            {
                UserName = _userModel.UserName,
                Email = _userModel.Email,
                SignupDate = DateTime.Now
            };
            // Se crea el usuario en la base de datos
            var result = await _userManager.CreateAsync(usuario, _userModel.Password);
            // Se genera el codigo para confirmar el email del usuario recien creado
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            // Se codifica el token para poder enviarlo por parametro
            var encodedToken = code.Replace("/", "_").Replace("+", "-").Replace("=", ".");
            // Busco el ID del template que será usado en el correo a enviar.
            var templateID = _appSettings.ConfirmAccountTemplateID;
            // Se crea el link que será anexado al template del correo
            var callbackURL = clientBaseURI + "account-confirmed/" + usuario.Id + "/" + encodedToken;

            // Se crea el mensaje con sus detalles para el envío
            var emailDetails = new SendEmailDetails
            {
                FromName = "MoneyUCAB",
                FromEmail = "moneyucab@gmail.com",
                ToName = _userModel.UserName,
                ToEmail = _userModel.Email,
                Subject = "MoneyUCAB - Confirma tu correo electrónico",
                TemplateID = templateID,
                TemplateData = new EmailData
                {
                    Name = _userModel.UserName,
                    URL = callbackURL,
                    Message = "¡Nos emociona muchísimo tenerte en la familia! " +
                                "Para ello, es indispensable que confirmes tu cuenta para gozar de nuestros servicios. " +
                                "Solo haz click en el botón.",
                    ButtonTitle = "Confirmar cuenta"
                }
            };

            // Se envía el mensaje al correo del usuario registrado
            await _emailSender.SendEmailAsync(emailDetails);
            //Se debe ingresar en este punto la validación DAO con el sistema propio y no con Identity

            //-------------------------------------------------------

            return result;
        }

    }
}