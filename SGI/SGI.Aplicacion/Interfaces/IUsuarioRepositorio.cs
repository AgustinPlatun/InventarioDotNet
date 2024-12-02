namespace SGI.Aplicacion;
public interface IUsuarioRepositorio{
    int? UsuarioAlta(string nombre, string apellido, string email, string password);
    void UsuarioBaja(string email);
    void UsuarioModificacion(int? idUsuario,string nombre, string apellido, string email,string password);

    List<Usuario> MostrarUsuarios();

    Usuario UsuarioInicioDeSesion(string email, string password);

    Usuario BuscarUsuario(int? Id);

    bool UsuarioValidarPermiso(Permiso.Permisos permiso, int idUsuario);

}