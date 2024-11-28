namespace SGI.Aplicacion;

public class ValidacionException : Exception
{
    public ValidacionException() : base("ValidacionException: No se cumple con la regla de validacion.") { }

    public ValidacionException(string mensaje) : base(mensaje) { }

    public ValidacionException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
}