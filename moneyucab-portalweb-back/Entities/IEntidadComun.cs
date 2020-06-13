using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Entities
{
    public interface  IEntidadComun
    {

        public void LlenadoDataNpgsql(NpgsqlDataReader data);

    }
}
