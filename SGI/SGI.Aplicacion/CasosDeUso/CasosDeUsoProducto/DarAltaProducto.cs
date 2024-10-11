namespace SGI.Aplicacion;
public class DarAltaProducto(ServicioDeAutorizacionProvisorio servicio){
    public void Lanzar(int idUsuario)
    {
        if(servicio.PoseeElPermiso(idUsuario)){
            Console.Write("Ingresar id del producto :");String id = Console.ReadLine() ?? "0";
            Console.Write("Ingresar nombre :");String nombre = Console.ReadLine() ?? " ";
            Console.Write("Ingresar descripcion :");String descripcion = Console.ReadLine() ?? " ";
            Console.Write("Ingresar precio unitario :");String precioUnitario = Console.ReadLine() ?? "0";
            Console.Write("Ingresar cantidad de stock disponible :");String stockDisponible = Console.ReadLine() ?? "0";

            Producto p = new Producto(int.Parse(id),nombre,descripcion,double.Parse(precioUnitario),int.Parse(stockDisponible));

            string documentoDeProductos = "../SGI.Repositorios/listadoProductos.txt";

            using (StreamWriter writer = new StreamWriter(documentoDeProductos, true))
            {
                writer.WriteLine($"{p.Id},{p.Nombre},{p.Descripcion},{p.PrecioUnitario},{p.StockDisponible},{p.FechaCreacion},{p.FechaUltimaModificacion},{p.CategoriaId}");
            }  
        }else{
            throw new ArgumentException ("EL USUARIO NO TIENE LOS PERMISOS NECESARIOS");
        }
    }
}