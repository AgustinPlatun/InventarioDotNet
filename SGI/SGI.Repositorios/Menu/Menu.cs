using System;
namespace SGI.Repositorios;

public class Menu{
    private string _opcion = "1";

    public string opcion
    {
        get { return _opcion; }
        set { _opcion = value; }
    }

    public void invocarMenu(){
    Console.WriteLine("---------------------------------------------------------------");
    Console.WriteLine("--------------------------- MENU ---------------------------");
    Console.WriteLine("--------- INGRESAR 1 PARA AGREGAR UN PRODUCTO ---------");
    Console.WriteLine("--------- INGRESAR 0 PARA SALIR ---------");
    Console.WriteLine("---------------------------------------------------------------");
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

    default:
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Numero invalido, ingrese un numero valido !");
        Console.WriteLine("---------------------------------------------");
        break;
}
}

private void crearProducto(){
    Console.Write("Ingresar id del producto :");String id = Console.ReadLine() ?? "0";
    Console.Write("Ingresar nombre :");String nombre = Console.ReadLine() ?? " ";
    Console.Write("Ingresar descripcion :");String descripcion = Console.ReadLine() ?? " ";
    Console.Write("Ingresar precio unitario :");String precioUnitario = Console.ReadLine() ?? "0";
    Console.Write("Ingresar cantidad de stock disponible :");String stockDisponible = Console.ReadLine() ?? "0";

    Producto p = new Producto(int.Parse(id),nombre,descripcion,double.Parse(precioUnitario),int.Parse(stockDisponible));

    string documentoDeProductos = "../SGI.Repositorios/Productos/Productos.txt";

    using (StreamWriter writer = new StreamWriter(documentoDeProductos, true))
    {
        writer.WriteLine($"{p.Id}, {p.Nombre}, {p.Descripcion}, {p.PrecioUnitario}, {p.StockDisponible}, {p.FechaCreacion}, {p.FechaUltimaModificacion}, {p.CategoriaId}");
    }
}
}