namespace SGI.Aplicacion;
using SGI.Aplicacion;

public class CasoDeUsoUsuarioIniciarSesion(IUsuarioRepositorio repo){
    public Usuario Ejecutar(string email, string password){
        string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
        return repo.UsuarioInicioDeSesion(email,passwordPasadaPorHash);
    }
}