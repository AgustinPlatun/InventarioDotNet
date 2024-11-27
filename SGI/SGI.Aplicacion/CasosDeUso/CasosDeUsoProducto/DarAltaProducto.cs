using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class DarAltaProducto(IProductoRepositorio repo) {

    public void Ejecutar (string nombre , string descripcion, double precioUnitario, int stockDisponible,int idCategoria) { 

            repo.ProductoAlta(nombre,descripcion,precioUnitario,stockDisponible,idCategoria);
    }

}