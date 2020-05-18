using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using System.ServiceModel.Security;
using Google.Apis.Auth.OAuth2;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using Google.Apis.Plus.v1.Data;
using static Google.Apis.Plus.v1.Data.Person;
using System.Collections.Generic;
using ServicioLotoUCAB.Servicio.Excepciones;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login.Utilidades;

namespace moneyucab_portalweb_back.PruebasUnitarias
{
    [TestClass]
    public class Utilidades
    {

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void EncriptacionValida()
        {
            
        }
    }
}
