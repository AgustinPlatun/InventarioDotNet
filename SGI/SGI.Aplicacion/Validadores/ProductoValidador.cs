namespace SGI.Aplicacion;

public static class ProductoValidador{
    public static void ValidarStockDisponible(int stockDisponible)
    {
        if (stockDisponible < 0)
        {
            throw new ArgumentException("El stock disponible NO PUEDE ser menor a 0");
        }
    }

    public static void ValidarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre NO puede estar vacío");
        }
    }

    public static void ValidarPrecioUnitario(double precioUnitario)
    {
        if (precioUnitario < 0)
        {
            throw new ArgumentException("El precio por unidad NO PUEDE ser menor a 0");
        }
    }
}