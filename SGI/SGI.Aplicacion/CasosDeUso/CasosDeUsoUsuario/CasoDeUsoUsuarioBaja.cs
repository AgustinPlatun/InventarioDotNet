namespace SGI.Aplicacion;
using SGI.Aplicacion;

public class CasoDeUsoUsuarioBaja(IUsuarioRepositorio repo){
    public void Ejecutar(string email){
        repo.UsuarioBaja(email);
    }
}