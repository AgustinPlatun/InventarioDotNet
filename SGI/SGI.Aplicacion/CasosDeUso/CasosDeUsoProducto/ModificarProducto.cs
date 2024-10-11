namespace SGI.Aplicacion;
using System;
public class ModificarProducto(ServicioDeAutorizacionProvisorio servicio){
    public void Lanzar(int id)
    {
        if(servicio.PoseeElPermiso(id)){
            Console.Write("Ingresar ID de producto a modificar :");
            string leerId = Console.ReadLine();

            string documentoDeProductos = "../SGI.Repositorios/listadoProductos.txt";
            var leido = File.ReadAllLines(documentoDeProductos);
            using (var writer = new StreamWriter(documentoDeProductos))
            {
                foreach (var linea in leido)
                {
                    var lineaLeida = linea.Split(',');
                    if (lineaLeida[0] != leerId)
                    {
                        writer.WriteLine(linea);
                    }else{
                        Console.WriteLine($"Informacion actual del producto : Nombre {lineaLeida[1]} Descripcion {lineaLeida[2]} PrecioUnitario{lineaLeida[3]}");
                        Console.WriteLine("---------------------------------------------------------------------------");
                        Console.Write("Ingresar nuevo nombre :");string nuevoNom =Console.ReadLine();
                        ProductoValidador.ValidarNombre(nuevoNom);
                        Console.Write("Ingresar nueva descripcion :");string nuevaDesc = Console.ReadLine();
                        Console.Write("Ingresar nuevo precio por unidad :");string nuevoPrecioUnitario = Console.ReadLine();
                        ProductoValidador.ValidarPrecioUnitario(double.Parse(nuevoPrecioUnitario));
                        writer.WriteLine($"{lineaLeida[0]},{nuevoNom},{nuevaDesc},{nuevoPrecioUnitario},{lineaLeida[4]},{DateTime.Now},{lineaLeida[6]},{lineaLeida[7]}");
                    }
                }
                
            }
        }else
        {
            throw new ArgumentException ("EL USUARIO NO TIENE LOS PERMISOS NECESARIOS");
        }
    }
}