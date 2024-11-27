public interface IProductoValidador
{
    void ValidarStockDisponible(int stockDisponible);
     void ValidarNombre(string nombre);
     void ValidarPrecioUnitario(double precioUnitario);
}