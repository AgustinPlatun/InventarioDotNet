namespace SGI.Aplicacion;
public class DarAltaCategoria(ICategoriaRepositorio repo)
{

    public void validarAlta(string nombre, string descripcion)
    {
            repo.CategoriaAlta(nombre,descripcion);
    }
}