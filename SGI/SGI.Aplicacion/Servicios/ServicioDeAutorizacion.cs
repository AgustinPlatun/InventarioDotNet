namespace SGI.Aplicacion;

public class ServicioAutorizacion(IUsuarioRepositorio repo) : IServicioAutorizacion
{
    public bool PoseeElPermiso(Permiso.Permisos permiso, int idUsuario){
        return repo.UsuarioValidarPermiso(permiso, idUsuario);
    }
    public bool EsAdmin(int? idUsuario){
        return idUsuario == 1;
    }
}