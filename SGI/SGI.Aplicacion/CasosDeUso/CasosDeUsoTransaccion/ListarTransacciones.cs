using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class ListarTransacciones(ITransaccionRepositorio repo) 
{
    public List <Transaccion> Listar() 
    { 
        return repo.ListarTransacciones();
    }

}