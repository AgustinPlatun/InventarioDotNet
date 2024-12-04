using SGI.Aplicacion;

namespace SGI.Aplicacion;
public class CasoDeUsoUsuarioAlta (IUsuarioRepositorio repo, UsuarioValidador validador, ServicioAutorizacion autorizacion)
{
    public void Ejecutar(string nombre, string apellido, string email, string password)
    {
        if( validador.Validar(email))
        {
            string passwordPasadaPorHash = ServicioFuncionHash.FuncionHashSHA256(password);
            int? idUsuario = repo.UsuarioAlta(nombre, apellido, email, passwordPasadaPorHash);
            if( autorizacion.EsAdmin(idUsuario))
            {
                List<Permiso.Permisos> permisos = new List<Permiso.Permisos>{Permiso.Permisos.categoriaalta,
                Permiso.Permisos.productoalta,
                Permiso.Permisos.categoriabaja,
                Permiso.Permisos.categoriamodificacion,
                Permiso.Permisos.productobaja,
                Permiso.Permisos.productomodificacion,
                Permiso.Permisos.transaccionalta,
                Permiso.Permisos.transaccionbaja,
                Permiso.Permisos.usuarioalta,
                Permiso.Permisos.usuariobaja,
                Permiso.Permisos.usuariomodificacion};
            }
        }else
        {
            throw new ValidacionException("El email ingresado ya se encuentra registrado !");
        }
    }
}
