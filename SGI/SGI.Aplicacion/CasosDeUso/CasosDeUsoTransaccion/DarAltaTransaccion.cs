using System.Security;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class DarAltaTransaccion(ITransaccionRepositorio repo) {
    public void Ejecutar (int _idProducto,int unaCant,TipoTransaccion tipo) { 
            repo.TransaccionAlta(_idProducto,unaCant,tipo);
    }

}