using Npgsql;

namespace Comunes.Comun
{
    public interface IFormularioInsert
    {

        void LlenadoDataForm(NpgsqlCommand ComandoSQL);

    }
}
