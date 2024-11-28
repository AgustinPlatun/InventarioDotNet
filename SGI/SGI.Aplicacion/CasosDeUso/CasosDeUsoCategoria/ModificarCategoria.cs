namespace SGI.Aplicacion;

public class ModificarCategoria(ICategoriaRepositorio repo)
{
    public void validarModificacion(int idABuscar,string nombre,string descripcion){
        CategoriaValidador validador = new CategoriaValidador();
        validador.validarCategoria(nombre);
        repo.CategoriaModificar(idABuscar,nombre,descripcion);
    }
}