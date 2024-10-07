using Microsoft.VisualBasic;
using SGI.Repositorios;
using System.IO;

string documentoDeProductos = "../SGI.Repositorios/Productos/Productos.txt";
Producto p = new Producto(5,"palo","blanco",50.0,10);
using (StreamWriter writer = new StreamWriter(documentoDeProductos, true))
{
    writer.WriteLine($"{p.Id}, {p.Descripcion}, {p.Nombre}, {p.PrecioUnitario}");
}

p.Imprimir();
Console.ReadKey();


