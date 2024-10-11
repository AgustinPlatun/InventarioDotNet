namespace SGI.Aplicacion;

public class DarBajaCategoria() : ICasosDeUso 
{
    public void Lanzar(int idUsuario)
    {
        ServicioDeAutorizacionProvisorio servicio = new ServicioDeAutorizacionProvisorio();
        if(!servicio.PoseeElPermiso(idUsuario)){
            throw new ArgumentException ("EL USUARIO NO TIENE LOS PERMISOS NECESARIOS");
            }
        Console.Write("Ingresar id de categoria a eliminar :");string idCategoria = Console.ReadLine();
        string documentoDeProductos = "../SGI.Repositorios/listadoCategorias.txt";
        if (buscar(idCategoria) == false)
        {
            Console.WriteLine("Hay un producto con ID de categoria asociada.");
        } else 
        {
            var documentoLeido = File.ReadAllLines(documentoDeProductos);
            using (var documentoSobreescrito = new StreamWriter(documentoDeProductos))
            {
                foreach (var linea in documentoLeido)
                {
                    var lineaLeida = linea.Split(",");
                    if (lineaLeida[0] != idCategoria)
                    {
                        documentoSobreescrito.WriteLine(linea);
                    }
                }
            }
        }
    }
    private static bool buscar(String idCategoria)
    {
    string documentoDeProductos = "../SGI.Repositorios/listadoProductos.txt";
    var documentoLeido = File.ReadAllLines(documentoDeProductos);
        foreach (var linea in documentoLeido)
        {
            var lineaLeida = linea.Split(",");
            if (lineaLeida[7] == idCategoria) 
            {
                return false;
            }
        }

    return true;
    }
}