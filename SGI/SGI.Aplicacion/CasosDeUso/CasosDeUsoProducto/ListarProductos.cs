using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class ListarProductos(IProductoRepositorio repo) {
    public List <Producto> Ejecutar() { 
            return repo.ListarProductos(); 
    }
}