using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComEstadoCivil : EntidadComun, IEntidadComun
    {
        public int idEstadoCivil { get; set; }
        public string descripcion { get; set; }
        public char codigo { get; set; }
        public int estatus { get; set; }

        public ComEstadoCivil()
        {

        }

        public ComEstadoCivil(int IdEstadoCivil, string Descripcion, char Codigo, int Estatus)
        {
            this.idEstadoCivil = IdEstadoCivil;
            this.descripcion = Descripcion;
            this.codigo = Codigo;
            this.estatus = Estatus;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idEstadoCivil = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.codigo = Data.GetChar(2 + offset);
            this.estatus = Data.GetInt32(3 + offset);
        }
    }
}
