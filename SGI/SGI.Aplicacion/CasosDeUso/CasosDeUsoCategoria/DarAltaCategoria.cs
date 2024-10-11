
namespace SGI.Aplicacion;
public class DarAltaCategoria(ServicioDeAutorizacionProvisorio servicio) { 
public void crearCategoria(int idUsuario)
{
    if(servicio.PoseeElPermiso(idUsuario)){
        Console.Write("-Ingresar ID de la categoria:"); 
        int id = int.Parse(Console.ReadLine() ?? "-1");
        Console.Write("-Ingresar nombre de la categoria:");
        String nombre = Console.ReadLine();
        CategoriaValidador.validacionException(nombre);
        Console.Write("-Ingresar descripcion de la categoria:");
        String descripcion = Console.ReadLine() ?? "";
        Categoria cat1 = new Categoria(id,nombre,descripcion);
    }else{
        throw new ArgumentException ("EL USUARIO NO TIENE LOS PERMISOS NECESARIOS");
    }

}
}