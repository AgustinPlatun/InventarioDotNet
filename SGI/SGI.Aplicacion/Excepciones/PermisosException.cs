namespace SGI.Aplicacion;

public class PermisosException : Exception
{
    public PermisosException() : base("No hay permisos suficientes.") { }

    public PermisosException(string mensaje) : base(mensaje) { }

    public PermisosException(string mensaje, Exception innerException) : base(mensaje, innerException) { }

}