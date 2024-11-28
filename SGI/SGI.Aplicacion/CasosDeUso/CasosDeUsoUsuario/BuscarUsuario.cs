using SGI.Aplicacion;

namespace SGI.Aplicacion;
public class BuscarUsuario (IUsuarioRepositorio repo){
    public Usuario Ejecutar(int? Id){
            return repo.BuscarUsuario(Id);
    }
}