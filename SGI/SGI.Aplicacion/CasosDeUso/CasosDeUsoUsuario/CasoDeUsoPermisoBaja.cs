using SGI.Aplicacion;
public class CasoDeUsoPermisoBaja(IUsuarioRepositorio repo)
{
    public void Ejecutar(List<Permiso.Permisos> permiso,int idUsuario)
    {
        repo.agregarPermisos(permiso,idUsuario);
    }
}