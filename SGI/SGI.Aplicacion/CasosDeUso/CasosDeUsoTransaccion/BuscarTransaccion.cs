using System;
namespace SGI.Aplicacion;

public class BuscarTransaccion() : ICasosDeUso { 
    public void Lanzar(int idUsuario) { 

        ServicioDeAutorizacionProvisorio servicio = new ServicioDeAutorizacionProvisorio();
        if(!servicio.PoseeElPermiso(idUsuario)){
            throw new ArgumentException ("EL USUARIO NO TIENE LOS PERMISOS NECESARIOS");
            }
            
        Console.WriteLine(" Ingrese el ID de la transaccion a buscar  ");String id =Console.ReadLine() ?? "0";  

        string documentoTransaccion = "../SGI.Repositorios/listadoTransacciones.txt";
        string documentoProductos = "../SGI.Repositorios/listadoProductos.txt";

        try 
        { 
            var trans = File.ReadAllLines(documentoTransaccion);
            var transaccionenc = trans.FirstOrDefault(t => t.Split(",")[0] == id);

            if (transaccionenc != null) { 
                Console.WriteLine(transaccionenc);
                var campost = transaccionenc.Split(",");
                string idProd = campost[1];
                var productos = File.ReadAllLines(documentoProductos);
                var productoenc = productos.FirstOrDefault(p => p.Split(",")[0] == idProd);
                if (productoenc != null) {
                    Console.WriteLine(productoenc);
                }
                else {
                    throw new ArgumentException($"No se encontro un producto con ID {idProd}");
                }

            }
            else 
            { 
                throw new ArgumentException ($"No se encontro una transaccion con ID {id}");
            }
        }
        catch (Exception ex) { 
            Console.WriteLine($" Error en la lectura del archivo {ex.Message}");
        }
    
    }

}