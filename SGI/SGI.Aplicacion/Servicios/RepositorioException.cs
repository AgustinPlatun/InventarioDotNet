namespace SGI.Aplicacion;

public class RepositorioException : Exception
{
    public RepositorioException() : base("RepositorioException: La entidad no existe en el repositorio.") { }

    public RepositorioException(string mensaje) : base(mensaje) { }

    public RepositorioException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
}