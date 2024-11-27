namespace SGI.Aplicacion;
using SGI.Aplicacion;

public class MostrarUsuarios(IUsuarioRepositorio repo){
    public List<Usuario> Ejecutar(){
        return repo.MostrarUsuarios();
    }
}