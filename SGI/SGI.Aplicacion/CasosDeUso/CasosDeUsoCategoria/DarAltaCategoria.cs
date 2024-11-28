namespace SGI.Aplicacion;
public class DarAltaCategoria(ICategoriaRepositorio repo)
{

    public void validarAlta(string nombre, string descripcion)
    {
        CategoriaValidador validador = new CategoriaValidador();
            validador.validarCategoria(nombre);
            repo.CategoriaAlta(nombre,descripcion);
    }
}