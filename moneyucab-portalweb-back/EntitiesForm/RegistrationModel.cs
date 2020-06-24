using Comunes.Comun;
using NpgsqlTypes;
using System;

namespace moneyucab_portalweb_back.EntitiesForm
{
    public class RegistrationModel : LoginModel
    {
        public int idTipoUsuario { get; set; }
        public int idTipoIdentificacion { get; set; }
        public int ano_registro { get; set; }
        public int mes_registro { get; set; }
        public int dia_registro { get; set; }
        public int nro_identificacion { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public int estatus { get; set; }
        public Boolean comercio { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int ano_nacimiento { get; set; }
        public int mes_nacimiento { get; set; }
        public int dia_nacimiento { get; set; }
        public string razon_social { get; set; }


        public ComUsuario Formatear_Formulario()
        {
            if (this.comercio)
            {
                ComComercio comercio_reg = new ComComercio(razon_social, nombre, apellido);
                ComTipoIdentificacion tipoIdentificacion = new ComTipoIdentificacion(idTipoIdentificacion, 'v', "", 1);
                ComUsuario usuario = new ComUsuario(comercio_reg, null, tipoIdentificacion, 0, "", UserName, new NpgsqlDate(ano_registro, mes_registro, dia_registro), nro_identificacion, Email, telefono, direccion, 1, Password);
                return usuario;
            }
            else
            {
                ComTipoIdentificacion tipoIdentificacion = new ComTipoIdentificacion(idTipoIdentificacion, 'v', "", 1);
                ComEstadoCivil estadoCivil = new ComEstadoCivil(1, "", 's', 1);
                ComPersona persona = new ComPersona(estadoCivil, nombre, apellido, new NpgsqlDate(ano_nacimiento, mes_nacimiento, dia_nacimiento));
                ComUsuario usuario = new ComUsuario(null, persona, tipoIdentificacion, 0, "", UserName, new NpgsqlDate(ano_registro, mes_registro, dia_registro), nro_identificacion, Email, telefono, direccion, 1, Password);
                return usuario;
            }
        }
        
    }
}
