using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComParametro : EntidadComun, IEntidadComun
    {
        public ComTipoParametro tipoParametro = new ComTipoParametro();
        public ComFrecuencia frecuencia = new ComFrecuencia();
        public int idParametro { get; set; }
        public string nombre { get; set; }
        public int estatus { get; set; }

        public ComParametro()
        {

        }

        public ComParametro(int idParametro)
        {
            this.idParametro = idParametro;
        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idParametro = Data.GetInt32(0 + offset);
            this.nombre = Data.GetString(3 + offset);
            this.estatus = Data.GetInt32(4 + offset);
            this.tipoParametro.offset = 5 + offset;
            this.tipoParametro.LlenadoDataNpgsql(Data);
            this.frecuencia.offset = 8 + offset;
            this.frecuencia.LlenadoDataNpgsql(Data);
        }
    }
}
