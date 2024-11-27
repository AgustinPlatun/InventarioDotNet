namespace SGI.Aplicacion;

public class ModificarCategoria(ICategoriaRepositorio repo)
{
    public void validarModificacion(int idABuscar,string nombre,string descripcion){
        repo.CategoriaModificar(idABuscar,nombre,descripcion);
    }
}