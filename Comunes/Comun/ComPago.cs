using Npgsql;
using NpgsqlTypes;
using System;

namespace Comunes.Comun
{
    public class ComPago : EntidadComun, IEntidadComun
    {
        public int idPago { get; set; }
        public int idUsuarioSolicitante { get; set; }
        public int idUsuarioReceptor { get; set; }
        public NpgsqlDate fecha { get; set; }
        public string monto { get; set; }
        public string estatus { get; set; }
        public string referencia { get; set; }

        public ComPago()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idPago = Data.GetInt32(0 + offset);
            this.idUsuarioSolicitante = Data.GetInt32(1 + offset);
            this.idUsuarioReceptor = Data.GetInt32(2 + offset);
            this.fecha = Data.GetDate(3 + offset);
            this.monto = Data.GetString(4 + offset);
            this.estatus = Data.GetString(5 + offset);
            try
            {
                this.referencia = Data.GetString(6 + offset);
            }
            catch (InvalidCastException)
            {
                this.referencia = null;
            }
        }
    }
}
