using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoIdentificacion : EntidadComun, IEntidadComun
    {
        public int idTipoIdentificacion { get; set; }
        public char codigo { get; set; }
        public string descripcion { get; set; }
        public int estatus { get; set; }

        public ComTipoIdentificacion()
        {

        }

        public ComTipoIdentificacion(int IdTipoIdentificacion, char Codigo, string Descripcion, int Estatus)
        {
            this.idTipoIdentificacion = IdTipoIdentificacion;
            this.codigo = Codigo;
            this.descripcion = Descripcion;
            this.estatus = Estatus;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idTipoIdentificacion = Data.GetInt32(0 + offset);
            this.codigo = Data.GetChar(1 + offset);
            this.descripcion = Data.GetString(2 + offset);
            this.estatus = Data.GetInt32(3 + offset);
        }
    }
}
