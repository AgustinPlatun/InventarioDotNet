using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class ListarTransacciones(ITransaccionRepositorio repo) 
{
    public void Listar() 
    { 
        repo.ListarTransacciones();   
    }

}