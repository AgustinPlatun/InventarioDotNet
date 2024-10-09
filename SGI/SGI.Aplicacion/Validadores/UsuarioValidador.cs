enum Permiso {
    
}
public static class UsuarioValidador {

public static bool validarUsuario(int id)
{
    if (id == 1)
    {
        return true;
    } else 
    {
        return false;
    }
}
public static void permisosException(bool respuestaPermisos) {
    if (respuestaPermisos == false)
    {
        throw new ArgumentException("PermisosException: El usuario no posee los permisos adecuados");
    }
}
}