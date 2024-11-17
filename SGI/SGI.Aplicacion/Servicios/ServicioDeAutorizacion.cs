public class ServicioAutorizacion;  
{
    private readonly _servicioAutorizacion;
    public bool TienePermiso(Usuario usuario, string permiso)
    {
        return usuario.Permisos.Contains(permiso);
    }
}