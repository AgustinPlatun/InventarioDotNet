namespace SGI.Aplicacion;
public class MostrarCategorias (ICategoriaRepositorio metodoRepo) {

    public List<Categoria> Ejecutar () {
        return metodoRepo.MostrarCategorias();
    }
}