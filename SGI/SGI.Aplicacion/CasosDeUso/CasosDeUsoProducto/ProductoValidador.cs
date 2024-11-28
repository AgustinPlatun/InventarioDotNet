namespace SGI.Aplicacion;


public  class ProductoValidador : IProductoValidador{
    public  void ValidarStockDisponible(int stockDisponible)
    {
        if (stockDisponible <= 0)
        {
            throw new ValidacionException("El stock disponible no puede ser menor o igual a cero.");
        }
    }

    public void ValidarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ValidacionException("El nombre no puede estar vacío");
        }
    }

    public  void ValidarPrecioUnitario(double precioUnitario)
    {
        if (precioUnitario <= 0)
        {
            throw new ValidacionException("El precio por unidad no puede ser menor o igual a cero.");
        }
    }
}