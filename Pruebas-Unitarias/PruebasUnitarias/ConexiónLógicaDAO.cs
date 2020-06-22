using Comunes.Comun;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;
using Xunit.Sdk;

namespace Pruebas_Unitarias.PruebasUnitarias
{
    [TestClass]
    public class ConexiónLógicaDAO
    {
        private ComUsuario usuario;
        private ComCuenta cuenta;
        private ComTarjeta tarjeta;
        private ComUsuarioParametro parametro;

        [TestInitialize]
        public void InicializacionValores()
        {
            ComEstadoCivil estadoCivil = new ComEstadoCivil(1, "EstadoCivil", 'a', 2);
            ComPersona persona = new ComPersona( estadoCivil, "Pedro", "Faria", new NpgsqlDate(1998, 5, 30));
            ComComercio comercio = new ComComercio("Carnicería C.A", "Pedro", "Faria");
            ComTipoIdentificacion tipoIdentificacion = new ComTipoIdentificacion(1, 'v', "venezolano", 1);
            ComTipoCuenta tipoCuenta = new ComTipoCuenta(1);
            ComTipoTarjeta tipoTarjeta = new ComTipoTarjeta(1);
            ComBanco banco = new ComBanco(1);
            cuenta = new ComCuenta(tipoCuenta, banco, 1,"1231023");
            tarjeta = new ComTarjeta(tipoTarjeta, banco, 1, 104434, new NpgsqlDate(2021, 5, 30), 131, 1);
            usuario = new ComUsuario(comercio, persona, tipoIdentificacion, 1, "epale", "CODE", new NpgsqlDate(2020, 5, 30), 26466404, "pjfariakiddo@gmail.com", "04123746609", "Candelaria", 1, "Password");
            usuario = new ComUsuario(comercio, persona, tipoIdentificacion, 1, "epale", "CODE2", new NpgsqlDate(2020, 5, 30), 26466404, "pjfariakiddo2@gmail.com", "04123746609", "Candelaria", 1, "Password");
            parametro = new ComUsuarioParametro(1, 1, "200", 1);
        }

        [TestMethod]
        public void RegistroCuentaExitoso()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.RegistroCuenta(cuenta);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void RegistroTarjetaExitoso()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.RegistroTarjeta(tarjeta);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void EstablecerParametro()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.EstablecerParametro(parametro);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        [TestCategory("Registro")]
        public void RegistroUsuarioPersonaExitoso()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.RegistroUsuarioPersona(usuario);
            Assert.AreEqual(null, null);
        }

        [TestMethod]
        [TestCategory("Registro")]
        public void RegistroUsuarioComercioExitoso()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.RegistroUsuarioComercio(usuario);
            Assert.AreEqual(null, null);
        }
    }
}
