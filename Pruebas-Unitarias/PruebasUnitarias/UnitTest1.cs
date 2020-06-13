using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;
using Xunit.Sdk;

namespace Pruebas_Unitarias.PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConexionABaseDeDatos()
        {
             DAO.DAOBase dao = new DAO.DAOBase();
             dao.Conectar();
             dao.Desconectar();
             Assert.AreEqual(null, null);
        }

        [TestMethod]
        public void HistorialOperaciones()
        {
            DAO.DAOBase dao = new DAO.DAOBase();
            dao.HistorialOperacionesTarjeta(1);
            Assert.AreEqual(null, null);
        }
    }
}
