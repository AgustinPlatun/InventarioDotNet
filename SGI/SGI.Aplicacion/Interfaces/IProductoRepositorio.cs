namespace SGI.Aplicacion; 

public interface IProductoRepositorio 
{
    void ProductoAlta(int idUsuario,string nombre, string descripcion, double precioUnitario, int stockDisponible,int idCategoria);
    void ProductoBaja(int idProducto);
    void ProductoModificar(int idProducto,string nuevoNombre, string nuevaDesc, double nuevoPrecio, int nuevoStock, int nuevaCategoria); 
    List <Producto> ListarProductos();
}

