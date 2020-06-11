
using System.Threading.Tasks;

namespace moneyucab_portalweb_back.Comandos
{
    public interface IComando<TSalida>
    {
        Task<TSalida> Ejecutar();
    }
}
