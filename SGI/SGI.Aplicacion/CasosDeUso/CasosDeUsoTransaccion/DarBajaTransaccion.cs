using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class DarBajaTransaccion(ITransaccionRepositorio repo, ServicioAutorizacion autorizador) 
{
    public void Ejecutar(int idUsuario,int id) 
    { 
        if (autorizador.PoseeElPermiso(Permiso.Permisos.transaccionbaja,idUsuario))
        {
            repo.TransaccionBaja(id);
        } else
        {
            throw new AutorizacionException("No posee el permiso necesario para realizar una baja de transaccion.");
        }
    }

}