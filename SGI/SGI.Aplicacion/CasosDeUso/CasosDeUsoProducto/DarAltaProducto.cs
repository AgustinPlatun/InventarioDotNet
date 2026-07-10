using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
using Microsoft.Extensions.Logging;

public class DarAltaProducto(IProductoRepositorio repositorio, ServicioAutorizacion autorizacion, ILogger<DarAltaProducto> logger) 
{
    public void Ejecutar (int idUsuario, string nombre , string descripcion, double precioUnitario, int stockDisponible,int idCategoria) 
    { 
        try {
            Permiso.Permisos permiso = Permiso.Permisos.productoalta;
            if(autorizacion.PoseeElPermiso(permiso,idUsuario))
            {
                ProductoValidador validador = new ProductoValidador();
                validador
                    .ValidarPrecioUnitario(precioUnitario);
                validador
                    .ValidarStockDisponible(stockDisponible);
                repositorio
                    .ProductoAlta(nombre,descripcion,precioUnitario,stockDisponible,idCategoria);
            }else{
                throw new AutorizacionException("No posee el permiso necesario para realizar una alta de producto.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al dar de alta el producto {Nombre}", nombre);
            throw;
        }
    }
}