namespace SGI.Aplicacion;
using System;
public class DarBajaProducto(ServicioDeAutorizacionProvisorio servicio){
    public void Lanzar(int idUsuario)
    {
        if(servicio.PoseeElPermiso(idUsuario))
        {
            Console.Write("Ingresar id de producto a eliminar :");
            string leerId = Console.ReadLine();
            string documentoDeProductos = "../SGI.Repositorios/listadoProductos.txt";
            reescribirArchivo(documentoDeProductos,leerId,0);
            string documentoDeTransacciones = "../SGI.Repositorios/listadoTransacciones.txt";
            reescribirArchivo(documentoDeTransacciones,leerId,1);
        }else
        {
            throw new ArgumentException ("EL USUARIO NO TIENE LOS PERMISOS NECESARIOS");
        }
    }
    public void reescribirArchivo(string documento,string idLeida,int pos){
        var leido = File.ReadAllLines(documento);
        using (var writer = new StreamWriter(documento))
        {
            foreach (var linea in leido)
            {
                var lineaLeida = linea.Split(',');
                if (lineaLeida[pos] != idLeida)
                {
                    writer.WriteLine(linea);
                }
            }
            
        }
    }
}
