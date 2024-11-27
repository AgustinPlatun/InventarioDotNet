public class UsuarioValidador : IUsuarioValidador
{
    public void permisosException(Enum permiso,List<string>? listadoPermisos)
    {
        if (listadoPermisos == null || listadoPermisos.Count == 0)
        {
            throw new ArgumentException("PermisosException: No se tienen los permisos.");
        }
    
        string permisoSolicitado = permiso.ToString();
        if (!listadoPermisos.Contains(permisoSolicitado)) {
            throw new ArgumentException("PermisosException: No se tienen los permisos.");
        }
    }
}