namespace SGI.Aplicacion;

public class ModificarCategoria(): ICasosDeUso
{
    public void Lanzar(int idUsuario)
    {
        ServicioDeAutorizacionProvisorio servicio = new ServicioDeAutorizacionProvisorio();
        if(!servicio.PoseeElPermiso(idUsuario)){
            throw new ArgumentException ("EL USUARIO NO TIENE LOS PERMISOS NECESARIOS");
            }
        Console.Write("Ingresar id de categoria a modificar :");string idCategoria = Console.ReadLine();
        string documentoDeProductos = "../SGI.Repositorios/listadoCategorias.txt";
        var documentoLeido = File.ReadAllLines(documentoDeProductos);
            using (var documentoSobreescrito = new StreamWriter(documentoDeProductos))
            {
                foreach(var linea in documentoLeido){

                
                    var lineaLeida = linea.Split(",");
                    if (lineaLeida[0] != idCategoria)
                    {
                        documentoSobreescrito.WriteLine(linea);
                    } else
                    {
                        Console.WriteLine($"ID Actual: {lineaLeida[0]}");
                        Console.Write("-Ingresar modificacion de ID: ");
                        string id = Console.ReadLine();
                        Console.WriteLine($"Nombre Actual: {lineaLeida[1]}");
                        Console.Write("-Ingresar modificacion de nombre: ");
                        string nombre = Console.ReadLine();
                        Console.WriteLine($"-Descripcion Actual: {lineaLeida[2]}");
                        Console.Write("Ingresar modificacion de descripcion:");
                        string descripcion = Console.ReadLine();
                        documentoSobreescrito.WriteLine($"{id},{nombre},{descripcion},{lineaLeida[3]},{DateTime.Now}");
                    }
                }
            }
    }
}