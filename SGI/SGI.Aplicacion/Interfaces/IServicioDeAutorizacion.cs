namespace SGI.Aplicacion;
using SGI.Aplicacion;

public interface IServicioAutorizacion {
    bool PoseeElPermiso(Permiso.Permisos permiso, int idUsuario);

    bool EsAdmin(int? idUsuario);
    
}