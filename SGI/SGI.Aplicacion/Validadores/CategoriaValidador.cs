namespace SGI.Aplicacion;
static class CategoriaValidador
{
    public static void validacionException(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre NO puede estar vacio.");
            }
        }   
}