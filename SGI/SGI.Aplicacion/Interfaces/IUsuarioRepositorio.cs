namespace SGI.Aplicacion;

public interface IUsuarioRepositorio{
    int? UsuarioAlta(string nombre, string apellido, string email, string password);
}