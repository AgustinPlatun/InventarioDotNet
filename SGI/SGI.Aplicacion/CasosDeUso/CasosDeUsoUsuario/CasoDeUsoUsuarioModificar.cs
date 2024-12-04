using SGI.Aplicacion;

namespace SGI.Aplicacion;
public class CasoDeUsoUsuarioModificar (IUsuarioRepositorio repo){
    public void Ejecutar(int? idUsuario,string nombre, string apellido, string email, string password){
        repo.UsuarioModificacion(idUsuario,nombre,apellido,email, password); 
    }
}