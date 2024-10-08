using System;
namespace SGI.Repositorios;
using SGI.Aplicacion;
public class Menu{
    private string _opcion = "1";

    public string opcion
    {
        get { return _opcion; }
        set { _opcion = value; }
    }

    public void invocarMenu(){
    Console.WriteLine("---------------------------SISTEMA DE GESTION DE INVENTARIO---------------------------");
    Console.WriteLine("-------------------------              MENU                 -------------------------");
    Console.WriteLine("---------------------         1- Agregar un producto.     ---------------------");
    Console.WriteLine("---------------------         2- Agregar una transaccion. ---------------------");
    Console.WriteLine("---------------------         3- Agregar una categoria.   ---------------------");
    Console.WriteLine("---------------------         0- Salir.                   ---------------------");
    Console.WriteLine("-------------------------------------------------------------------------------------");
    }

public void elegirOpciones(){
    switch (this.opcion)
{
    case "0":
        Console.WriteLine("-- Hasta luego! --");
        break;

    case "1":
        crearProducto();
        break;
    case "2": 
        crearTransaccion();
        break;
    case "3":
        crearCategoria();
        break;

    default:
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Numero invalido, ingrese un numero valido !");
        Console.WriteLine("---------------------------------------------");
        break;
}
}

private void crearCategoria()
{
    Console.Write("-Ingresar ID de la categoria:"); 
    int id = int.Parse(Console.ReadLine() ?? "-1");
    Console.Write("-Ingresar nombre de la categoria:");
    String nombre = Console.ReadLine();
    CategoriaValidador.validacionException(nombre);
    Console.Write("-Ingresar descripcion de la categoria:");
    String descripcion = Console.ReadLine() ?? "";
    Categoria cat1 = new Categoria(id,nombre,descripcion);

}
private void crearProducto()
{
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
}

private void crearTransaccion() {
    Console.Write("Ingresar ID de la transaccion : ");String id = Console.ReadLine() ?? "0";
    Console.Write("Ingresar ID del PRODUCTO : ");String idProd = Console.ReadLine() ?? "0";
    Console.Write("Ingresar TIPO DE TRANSACCION (entrada o salida) : ");String tipo= Console.ReadLine() ?? "";
    Console.Write("Ingresar cantidad del producto : "); String cant = Console.ReadLine() ?? "0"; 
    DateTime fecha = DateTime.Now;  

    Transaccion t = new Transaccion (int.Parse(id), int.Parse(idProd), tipo, int.Parse(cant),fecha); 
    
    string documentoTransaccion ="../SGI.Repositorios/listadoTransacciones.txt";

    using (StreamWriter writer = new StreamWriter(documentoTransaccion,true)) { 
        writer.WriteLine($"{t.getId()},{t.getProductoId()},{t.getTipo()},{t.getCantidad()},{t.getFecha()}");
    }

}


}