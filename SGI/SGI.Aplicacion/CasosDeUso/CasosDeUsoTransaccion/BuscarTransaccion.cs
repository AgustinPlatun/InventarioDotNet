using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class BuscarTransaccion(ITransaccionRepositorio repo) 
{
    public void Buscar(int id) 
    { 
        repo.BuscarTransaccion(id);
    }

}