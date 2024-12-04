using SGI.Aplicacion;

namespace SGI.Aplicacion;
public class ConsultaDePermisos (ServicioAutorizacion autorizacion){
    public bool Ejecutar(Permiso.Permisos permiso, int idUsuario){
        return autorizacion.PoseeElPermiso(permiso,idUsuario);
    }

    public bool admin(int idUsuario){
        return autorizacion.EsAdmin(idUsuario);
    }
    
}