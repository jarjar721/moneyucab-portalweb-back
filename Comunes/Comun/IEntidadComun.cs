using Npgsql;

namespace Comunes.Comun
{
    public interface IEntidadComun
    {

        void LlenadoDataNpgsql(NpgsqlDataReader data);

    }
}
