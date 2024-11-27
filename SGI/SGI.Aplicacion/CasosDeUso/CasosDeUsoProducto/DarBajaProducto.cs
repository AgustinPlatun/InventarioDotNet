using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class DarBajaProducto(IProductoRepositorio repo) {
    public void Ejecutar (int idProducto) { 
            repo.ProductoBaja(idProducto);
    }
}