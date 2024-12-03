namespace SGI.Aplicacion;
public class DarAltaCategoria(ICategoriaRepositorio repo, ServicioAutorizacion autorizador)
{

    public void validarAlta(int idUsuario,string nombre, string descripcion)
    {
        if (autorizador.PoseeElPermiso(Permiso.Permisos.categoriaalta,idUsuario))
        {   
        CategoriaValidador validador = new CategoriaValidador();
        validador.validarCategoria(nombre);
        repo.CategoriaAlta(nombre,descripcion);
        }
        else 
        {
            throw new AutorizacionException("No posee el permiso necesario para realizar una alta de categoria.");
        }
    }
}