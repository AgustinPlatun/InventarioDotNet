using System.Data.Common;

namespace SGI.Aplicacion;

public class DarBajaCategoria(ICategoriaRepositorio repo, ServicioAutorizacion autorizador) 
{   
    public void validarBaja(int idUsuario,int idABuscar)
    {
        if (autorizador.PoseeElPermiso(Permiso.Permisos.categoriabaja,idUsuario))
        {
        repo.CategoriaBaja(idABuscar);
        } else
        {
            throw new AutorizacionException("No posee el permiso necesario para realizar una baja de categoria.");
        }
    }
}