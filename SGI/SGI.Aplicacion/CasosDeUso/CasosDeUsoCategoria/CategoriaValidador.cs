using SGI.Aplicacion;

public class CategoriaValidador : ICategoriaValidador
{
    public void validarCategoria(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ValidacionException("El nombre no puede estar vacio.");
        }
    }
}