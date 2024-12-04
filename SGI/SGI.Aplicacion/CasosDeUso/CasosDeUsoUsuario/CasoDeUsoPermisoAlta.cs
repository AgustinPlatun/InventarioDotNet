using SGI.Aplicacion;

public class CasoDeUsoPermisoAlta (IUsuarioRepositorio repo)
{
    public void Ejecutar(List<Permiso.Permisos> permiso,int idUsuario){
        repo.agregarPermisos(permiso,idUsuario);
    }
}