namespace SGI.Aplicacion;

public class ModificarCategoria(ICategoriaRepositorio repo, ServicioAutorizacion autorizador)
{
    public void validarModificacion(int idUsuario,int idABuscar,string nombre,string descripcion)
    {
        if (autorizador.PoseeElPermiso(Permiso.Permisos.categoriamodificacion,idUsuario))
        {
        CategoriaValidador validador = new CategoriaValidador();
        validador.validarCategoria(nombre);
        repo.CategoriaModificar(idABuscar,nombre,descripcion);
        } else
        {
            throw new AutorizacionException("No posee el permiso necesario para realizar una modificacion de categoria.");
        }
    }
}