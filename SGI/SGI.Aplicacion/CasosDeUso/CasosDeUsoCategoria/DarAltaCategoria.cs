namespace SGI.Aplicacion;
public class DarAltaCategoria(): ICasosDeUso 
{
    public void Lanzar(int idUsuario)
    {
        ServicioDeAutorizacionProvisorio servicio = new ServicioDeAutorizacionProvisorio();
        if(!servicio.PoseeElPermiso(idUsuario)){
            throw new ArgumentException ("EL USUARIO NO TIENE LOS PERMISOS NECESARIOS");
            }
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