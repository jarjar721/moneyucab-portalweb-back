﻿using Npgsql;
using System;

namespace Comunes.Comun
{
    public class ComTipoOperacion : EntidadComun, IEntidadComun
    {
        public int idTipoIdentificacion { get; set; }
        public string descripcion { get; set; }
        public int estatus { get; set; }

        public ComTipoOperacion()
        {

        }

        public void LlenadoDataNpgsql(NpgsqlDataReader Data)
        {
            this.idTipoIdentificacion = Data.GetInt32(0 + offset);
            this.descripcion = Data.GetString(1 + offset);
            this.estatus = Data.GetInt32(2 + offset);
        }
    }
}
