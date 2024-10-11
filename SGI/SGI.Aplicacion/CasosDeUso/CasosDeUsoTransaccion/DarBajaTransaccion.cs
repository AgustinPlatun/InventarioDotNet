using System;
using System.IO;
using System.Linq;

namespace SGI.Aplicacion
{
    public class DarBajaTransaccion : ICasosDeUso
    {
        public void Lanzar(int idUsuario)
        {
            ServicioDeAutorizacionProvisorio servicio = new ServicioDeAutorizacionProvisorio();
            if(!servicio.PoseeElPermiso(idUsuario)){
                throw new ArgumentException ("EL USUARIO NO TIENE LOS PERMISOS NECESARIOS");
                }
            Console.Write("Ingresar ID de la transacción a encontrar: ");
            string id = Console.ReadLine() ?? "0";
            string documentoTransaccion = "../SGI.Repositorios/listadoTransacciones.txt";
            string documentoProducto = "../SGI.Repositorios/listadoProductos.txt";

            var lineas = File.ReadAllLines(documentoTransaccion).ToList();
            var transaccionABajar = lineas.FirstOrDefault(linea =>
            {
                var campos = linea.Split(",");
                return campos.Length > 0 && campos[0] == id;
            });

            if (transaccionABajar != null)
            {
                var camposTransaccion = transaccionABajar.Split(",");
                TipoTransaccion tipoTransaccion = (TipoTransaccion)Enum.Parse(typeof(TipoTransaccion), camposTransaccion[2]);
                string idProd = camposTransaccion[1];
                int cantidadTransaccion = int.Parse(camposTransaccion[3]);

                var lineasProductos = File.ReadAllLines(documentoProducto).ToList();
                bool productoActualizado = false;

                var lineasActualizadas = lineasProductos.Select(l =>
                {
                    var campos = l.Split(",");
                    if (campos.Length > 0 && campos[0] == idProd)
                    {
                        if (int.TryParse(campos[4], out int stock))
                        {
                            if (tipoTransaccion == TipoTransaccion.entrada)
                            {
                                campos[4] = (stock - cantidadTransaccion).ToString();
                            }
                            else if (tipoTransaccion == TipoTransaccion.salida)
                            {
                                campos[4] = (stock + cantidadTransaccion).ToString();
                            }
                            productoActualizado = true;
                        }
                    }
                    return string.Join(",", campos);
                }).ToList();
                if (productoActualizado)
                {
                    File.WriteAllLines(documentoProducto, lineasActualizadas);
                    Console.WriteLine($"El stock del producto con ID {idProd} ha sido actualizado correctamente.");
                }
                else
                {
                    Console.WriteLine($"EL PRODUCTO CON ID {idProd} NO FUE ENCONTRADO EN EL ARCHIVO DE PRODUCTOS.");
                }
                lineas.Remove(transaccionABajar);
                File.WriteAllLines(documentoTransaccion, lineas);
                Console.WriteLine($"La transacción con ID {id} fue dada de baja satisfactoriamente.");
            }
            else
            {
                throw new ArgumentException($"LA TRANSACCION DE ID {id} NO EXISTE O NO FUE CARGADA EN LA LISTA.");
            }
        }
    }
}
