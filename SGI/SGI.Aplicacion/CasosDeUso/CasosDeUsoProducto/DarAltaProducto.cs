using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class DarAltaProducto(IProductoRepositorio repo, ServicioAutorizacion autorizacion) {
    public void Ejecutar (int idUsuario, string nombre , string descripcion, double precioUnitario, int stockDisponible,int idCategoria) { 
        Permiso.Permisos permiso = Permiso.Permisos.productoalta;
        if(autorizacion.PoseeElPermiso(permiso,idUsuario)){
            ProductoValidador validador = new ProductoValidador();
            validador.ValidarPrecioUnitario(precioUnitario);
            validador.ValidarStockDisponible(stockDisponible);
            repo.ProductoAlta(idUsuario,nombre,descripcion,precioUnitario,stockDisponible,idCategoria);
        }else{
            throw new AutorizacionException("No posee el permiso necesario para crear un tramite");
        }
    }

}