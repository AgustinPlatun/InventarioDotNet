using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class ListarTransaccionesEntreFechas(ITransaccionRepositorio repo) {
    public void Listar(DateTime f1, DateTime f2) { 
            repo.ListarTransaccionesEntreFechas(f1,f2);
    }

}