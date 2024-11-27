using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class DarBajaTransaccion(ITransaccionRepositorio repo) {
    public void Ejecutar(int id) { 
            repo.TransaccionBaja(id);
    }

}