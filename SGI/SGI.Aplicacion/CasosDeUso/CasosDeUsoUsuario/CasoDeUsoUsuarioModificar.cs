using SGI.Aplicacion;

namespace SGI.Aplicacion;
public class CasoDeUsoUsuarioModificar (IUsuarioRepositorio repo){
    public void Ejecutar(int? idUsuario,string nombre, string apellido, string email, string password,List <Permiso.Permisos> permisos){
        repo.UsuarioModificacion(idUsuario,nombre,apellido,email, password, permisos); 
    }
}