using SGI.Aplicacion;
using Microsoft.EntityFrameworkCore;
namespace SGI.Repositorios;

public class RepositorioCategoria : ICategoriaRepositorio
{

    public RepositorioCategoria()
    {
        using (var context = new RepositorioContext())
        {
            context.Database.EnsureCreated(); //si la base de datos no existe se crea y devuelve true
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }

    }
    
    public void CategoriaAlta(string nombre, string descripcion) 
    {
        using (var db = new RepositorioContext())
        {
            var categoria = new Categoria(nombre,descripcion);
            db.Add(categoria);
            db.SaveChanges();
        }
    }

    public void CategoriaBaja(int id)
    {
        using (var db = new RepositorioContext())
        {
            var categoriaBajar = db.Categorias.FirstOrDefault(c => c.Id == id);
            var productoEncontrado = db.Productos.FirstOrDefault(p => p.CategoriaId == id);
            if (productoEncontrado != null)
            {
                throw new Exception($"El ID {id} tiene un producto asociado .");
            }
            if (categoriaBajar != null)
            {
                db.Remove(categoriaBajar);
                db.SaveChanges();
            }

        }
    }
    public void CategoriaModificar(int id,string nombre,string descripcion)
    {
        using (var db = new RepositorioContext())
        {
            var categoriaModificar = db.Categorias.FirstOrDefault(c => c.Id == id);
            if (categoriaModificar != null)
            {
                categoriaModificar.Nombre = nombre;
                categoriaModificar.Descripcion = descripcion;
                categoriaModificar.FechaUltimaModificacion = DateTime.Now;

                db.SaveChanges();
            }
        }
    }
        public List<Categoria> MostrarCategorias(){
        using (var db = new RepositorioContext()){
            var categorias = db.Categorias.ToList();
            return categorias;
        }
    }
}