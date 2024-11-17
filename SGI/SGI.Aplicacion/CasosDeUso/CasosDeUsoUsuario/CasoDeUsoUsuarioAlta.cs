using SGI.Aplicacion;

namespace SGI.Aplicacion;
public class CasoDeUsoUsuarioAlta (IUsuarioRepositorio repo){
    public void Ejecutar(string nombre, string apellido, string email, string password){
            string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
            int? idUsuario = repo.UsuarioAlta(nombre, apellido, email, passwordPasadaPorHash); 
    }
}