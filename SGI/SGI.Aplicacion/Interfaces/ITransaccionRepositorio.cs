namespace SGI.Aplicacion; 

public interface ITransaccionRepositorio 
{
    void TransaccionAlta(int productoId, int cantidad, TipoTransaccion tipo) ;
    void TransaccionBaja(int idProducto);
    Transaccion BuscarTransaccion(int id);
    List <Transaccion> ListarTransacciones();
    List <Transaccion> ListarTransaccionesEntreFechas(DateTime f1, DateTime f2); 
}

