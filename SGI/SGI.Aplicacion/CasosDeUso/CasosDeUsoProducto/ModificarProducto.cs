using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class ModificarProducto(IProductoRepositorio repo) {
    public void Ejecutar (int idProducto,string nuevoNombre, string nuevaDesc, double nuevoPrecio, int nuevoStock, int nuevaCategoria) { 
            ProductoValidador validador = new ProductoValidador();
            validador.ValidarPrecioUnitario(nuevoPrecio);
            validador.ValidarStockDisponible(nuevoStock);
            repo.ProductoModificar(idProducto,nuevoNombre,nuevaDesc,nuevoPrecio,nuevoStock,nuevaCategoria);
    }
}