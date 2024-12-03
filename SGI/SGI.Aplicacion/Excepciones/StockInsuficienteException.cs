namespace SGI.Aplicacion;

public class StockInsuficienteException : Exception
{
    public StockInsuficienteException() : base("StockInsuficienteException: No hay stock suficiente para realizar transaccion.") { }

    public StockInsuficienteException(string mensaje) : base(mensaje) { }

    public StockInsuficienteException(string mensaje, Exception innerException) : base(mensaje, innerException) { }

}