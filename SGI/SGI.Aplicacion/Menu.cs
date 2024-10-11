using System;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class Menu{
    private string _opcion = "4";
    Usuario usuario;

    ServicioDeAutorizacionProvisorio autorizacion = new ServicioDeAutorizacionProvisorio();

    public string Opcion
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
    Console.WriteLine("---------------------         4- Cambiar de usuario.      ---------------------");
    Console.WriteLine("---------------------         5- Para eliminar producto.  ---------------------");
    Console.WriteLine("---------------------         0- Salir.                   ---------------------");
    Console.WriteLine("-------------------------------------------------------------------------------------");
    }

public void elegirOpciones(){
    switch (this.Opcion)
{
    case "0":
        Console.WriteLine("-- Hasta luego! --");
        break;
    case "1":
        DarAltaProducto productoAlta = new DarAltaProducto(this.autorizacion);
        productoAlta.Lanzar(usuario.Id);
        break;
    case "3":
        DarAltaCategoria categoriaAlta = new DarAltaCategoria(this.autorizacion);
        categoriaAlta.crearCategoria(usuario.Id);
        break;
    case "4":
        cambiarDeUsuario();
        break;
    case "5":
        DarBajaProducto productoBaja = new DarBajaProducto(this.autorizacion);
        productoBaja.Lanzar(usuario.Id);
    break;

    default:
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Numero invalido, ingrese un numero valido !");
        Console.WriteLine("---------------------------------------------");
        break;
}
}

private void cambiarDeUsuario(){
    Console.Write("Ingresar id de usuario :");
    string id = Console.ReadLine();
    this.usuario = new Usuario(int.Parse(id));
}
}