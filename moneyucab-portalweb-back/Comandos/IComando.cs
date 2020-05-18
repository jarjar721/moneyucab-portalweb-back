
namespace moneyucab_portalweb_back.Comandos
{
    public interface IComando<TSalida>
    {
        TSalida Ejecutar();
    }
}
