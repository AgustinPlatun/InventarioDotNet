namespace SGI.Aplicacion;
public interface IUsuarioRepositorio
{
    int? UsuarioAlta(string nombre, string apellido, string email, string password);
    void UsuarioBaja(string email);
    void UsuarioModificacion(int? idUsuario,string nombre, string apellido, string email,string password); 
    List<Usuario> MostrarUsuarios();

    Usuario UsuarioInicioDeSesion(string email, string password);
    bool UsuarioValidarPermiso(Permiso.Permisos permiso, int idUsuario);
    bool EmailRepetido(string? email); 
    void agregarPermisos(List<Permiso.Permisos> permiso,int idUsuario);
    void eliminarPermisos(List<Permiso.Permisos> permiso,int idUsuario);
}