
namespace SGI.Aplicacion;
public static class DarAltaCategoria { 
public static void crearCategoria()
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
}