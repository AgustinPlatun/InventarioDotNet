namespace SGI.Aplicacion;
public class ServicioAutorizacion : IServicioAutorizacion
{
    public bool TienePermiso(Usuario usuario, string permiso)
    {
        return usuario.Permisos.Contains(permiso);
    }
}