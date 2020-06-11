
namespace Comandos
{
    public interface IComando<TSalida>
    {
        TSalida EjecutarAsync();
    }
}
