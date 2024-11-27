public class CategoriaValidador : ICategoriaValidador
{
    public void validarCategoria(string nombre){
    if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("ValidacionException: El nombre no puede estar vacio.");
            
    }
    }
}