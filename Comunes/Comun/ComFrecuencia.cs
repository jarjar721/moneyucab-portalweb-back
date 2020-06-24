using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComFrecuencia : EntidadComun, IEntidadComun
    {
        public int idFrecuencia { get; set; }
        public char codigo { get; set; }
        public string descripcion { get; set; }
        public int estatus { get; set; }

        public ComFrecuencia()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idFrecuencia = Data.GetInt32(0 + offset);
            this.codigo = Data.GetChar(1 + offset);
            this.descripcion = Data.GetString(2 + offset);
            this.estatus = Data.GetInt32(3 + offset);
        }
    }
}
