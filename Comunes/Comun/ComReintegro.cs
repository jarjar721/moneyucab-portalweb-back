using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComReintegro : EntidadComun, IEntidadComun
    {
        public int idReintegro { get; set; }
        public int idUsuarioSolicitante { get; set; }
        public int idUsuarioReceptor { get; set; }
        public NpgsqlDate fecha { get; set; }
        public string referencia_reintegro { get; set; }
        public string referencia { get; set; }
        public string estatus { get; set; }

        public ComReintegro()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idReintegro = Data.GetInt32(0 + offset);
            this.idUsuarioSolicitante = Data.GetInt32(1 + offset);
            this.idUsuarioReceptor = Data.GetInt32(2 + offset);
            this.fecha = Data.GetDate(3 + offset);
            this.referencia_reintegro = Data.GetString(4 + offset);
            try
            {
                this.referencia = Data.GetString(5 + offset);
            }
            catch (InvalidCastException)
            {
                this.referencia = null;
            }
            this.estatus = Data.GetString(6 + offset);
        }
    }
}
