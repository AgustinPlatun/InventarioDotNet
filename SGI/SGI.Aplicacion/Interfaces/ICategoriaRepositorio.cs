using SGI.Aplicacion;

public interface ICategoriaRepositorio{

    void CategoriaAlta(string nombre,string descripcion);
    void CategoriaBaja(int id);
    void CategoriaModificar(int id,string nombre,string descripcion);

}