using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class DarBajaProducto(IProductoRepositorio repositorio, ServicioAutorizacion autorizacion) {
    public void Ejecutar (int idUsuario,int idProducto) { 
        Permiso.Permisos permiso = Permiso.Permisos.productobaja;
        if(autorizacion.PoseeElPermiso(permiso,idUsuario)){
            repositorio.ProductoBaja(idProducto);
        }else{
            throw new AutorizacionException("No posee el permiso necesario para realizar una baja de producto !");
        }
    }
}