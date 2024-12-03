using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class DarAltaTransaccion(ITransaccionRepositorio repo,ServicioAutorizacion autorizador) 
{
    public void Ejecutar (int idUsuario,int _idProducto,int unaCant,TipoTransaccion tipo) 
    { 
        if (autorizador.PoseeElPermiso(Permiso.Permisos.transaccionalta,idUsuario))
        {
        repo.TransaccionAlta(_idProducto,unaCant,tipo);
        }else
        {
          throw new AutorizacionException("No posee el permiso necesario para realizar una alta de transaccion.");  
        }
    }

}