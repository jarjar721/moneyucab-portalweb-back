using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao.Login;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Excepciones;
using ServicioLotoUCAB.Servicio.Excepciones.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login;
using ServicioLotoUCAB.Servicio.Logica.Comandos.ComandosService.Login.Simples;
using ServicioLotoUCAB.Servicio.Logica.Comandos.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias
{
    [TestClass]
    public class Dao_y_Comandos
    {
        private Usuario user;
        private DAOBase dao;
        private Exception e;

        [TestInitialize]
        public void initialize()
        {
            
        }

        [TestMethod]
        public void InsertarUsuarioValido()
        {
            try
            {
                dao.InsertarUsuario(user);
            }
            catch (Exception ex)
            {
                e = ex;
            }
            Assert.IsNull(e);
        }

    }
}
