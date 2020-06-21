using Npgsql;

namespace Comunes.Comun
{
    public interface IFormularioRegistro
    {

        void LlenadoDataFormPersona(NpgsqlCommand ComandoSQL);
        void LlenadoDataFormComercio(NpgsqlCommand ComandoSQL);

    }
}
