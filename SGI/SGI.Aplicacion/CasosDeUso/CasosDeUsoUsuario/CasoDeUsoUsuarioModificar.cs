using SGI.Aplicacion;

namespace SGI.Aplicacion;
public class CasoDeUsoUsuarioModificar (IUsuarioRepositorio repo, UsuarioValidador validador){
    public void Ejecutar(int? idUsuario,string nombre, string apellido, string email, string password){
        if (!validador.Validar(email)) 
        {
            throw new ValidacionException("El email ingresado ya existe");
        };
        string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
        repo.UsuarioModificacion(idUsuario,nombre,apellido,email, passwordPasadaPorHash);
    }
}