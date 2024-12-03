using SGI.Aplicacion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace SGI.Repositorios;

public class RepositorioProducto : IProductoRepositorio
{
        public RepositorioProducto()
        {
            using (var context = new RepositorioContext())
            {
                context.Database.EnsureCreated();
            }
        }

        // Método para dar de alta un producto
        public void ProductoAlta(string nombre, string descripcion, double precioUnitario, int stockDisponible,int idCategoria)
        {
            try
            {
                
                using (var db = new RepositorioContext())
                {
                    var categoria = db.Categorias.FirstOrDefault(c => c.Id == idCategoria);
                    if (categoria == null) {
                        throw new Exception("No hay ninguna categoria asociada al ID ingresado.");
                    }
                    var producto = new Producto(nombre, descripcion, precioUnitario, stockDisponible, idCategoria);
                    db.Productos.Add(producto);  // Asegura que el producto se agregue a la tabla Productos
                    db.SaveChanges(); // Guarda los cambios en la base de datos

                }
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Error al agregar el producto: {dbEx.Message}");
                Console.WriteLine($"Inner Exception: {dbEx.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {dbEx.StackTrace}");
            }
        }

        // Método para dar de baja un producto
        public void ProductoBaja(int idProducto)
        {
            using (var db = new RepositorioContext())
            {
                // Buscar el producto con el id especificado
                var producto = db.Productos.FirstOrDefault(p => p.Id == idProducto);
                if (producto == null)
                {
                    throw new Exception($"Producto con ID {idProducto} no encontrado.");
                }
                db.Productos.Remove(producto); 
                db.SaveChanges(); 
            }
        }

    public void ProductoModificar(int idProducto, string nuevoNombre, string nuevaDesc, double nuevoPrecio, int nuevoStock, int nuevaCategoria) { 
        using (var db = new RepositorioContext()) 
        {   var producto= db.Productos.FirstOrDefault(p=> p.Id==idProducto); 
                if (producto == null) 
                {
                    throw new Exception ($"Producto con ID {idProducto} no encontrado. ");  
                }
                else {  
                     producto.Nombre = nuevoNombre;
                     producto.Descripcion = nuevaDesc;
                     producto.PrecioUnitario=nuevoPrecio;
                     producto.StockDisponible=nuevoStock;
                     producto.actualizarFechaMod(); 
                     producto.categoriaId=nuevaCategoria;
                     db.SaveChanges();  
                } 
        } 
    }
    public List <Producto> ListarProductos() 
    { using (var db = new RepositorioContext()) 
        { var productos = db.Productos.ToList();
            if (productos == null) 
            {
                throw new Exception (" Aun no se han cargado productos ");
            }
            else 
            { 
                return productos;  
            }
        }
    } 


}