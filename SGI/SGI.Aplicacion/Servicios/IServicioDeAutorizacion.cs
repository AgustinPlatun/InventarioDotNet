public interface IServicioAutorizacion
{
    bool TienePermiso(Usuario usuario, string permiso);
}