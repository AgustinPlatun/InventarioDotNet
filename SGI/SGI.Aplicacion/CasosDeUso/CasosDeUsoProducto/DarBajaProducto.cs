using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class DarBajaProducto(IProductoRepositorio repositorio, ServicioAutorizacion autorizacion) {
    public void Ejecutar (int idUsuario,int idProducto) { 
            repositorio.ProductoBaja(idProducto);
    }
}