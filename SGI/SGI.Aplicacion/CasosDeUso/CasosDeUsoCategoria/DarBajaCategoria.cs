using System.Data.Common;

namespace SGI.Aplicacion;

public class DarBajaCategoria(ICategoriaRepositorio repo) 
{   
    public void validarBaja(int idABuscar)
    {
        repo.CategoriaBaja(idABuscar);
    }
}