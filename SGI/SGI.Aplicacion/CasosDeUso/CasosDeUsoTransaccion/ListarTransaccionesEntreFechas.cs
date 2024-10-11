using System;
using System.Globalization;
using System.IO;
using System.Linq;
namespace SGI.Aplicacion;

public class ListarTransaccionesEntreFechas() : ICasosDeUso {
    public void Lanzar(int idUsuario)
    {
        Console.Write("Ingresar fecha desde donde se quiere listar (yyyy/MM/dd): ");
        DateTime fecha1;
        while (!DateTime.TryParse(Console.ReadLine(), out fecha1))
        {
            Console.WriteLine("Fecha no válida, por favor ingrese de nuevo (yyyy/MM/dd): ");
        }

        Console.Write("Ingresar segunda fecha hasta donde se quiere listar (yyyy/MM/dd): ");
        DateTime fecha2;
        while (!DateTime.TryParse(Console.ReadLine(), out fecha2))
        {
            Console.WriteLine("Fecha no válida, por favor ingrese de nuevo (yyyy/MM/dd): ");
        }

        string documentoTransaccion = "../SGI.Repositorios/listadoTransacciones.txt";
        string[] lineastexto = File.ReadAllLines(documentoTransaccion);

        foreach (string linea in lineastexto)
        {
            
            if (DateTime.TryParseExact(linea, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechabusq))
            {
                if (fechabusq >= fecha1 && fechabusq <= fecha2)
                {
                    Console.WriteLine($"Fecha dentro del rango: {fechabusq.ToString("yyyy-MM-dd")}");
                }
            }
            else
            {
                throw new ArgumentException($"Formato inválido: {linea}");
            }
        }
    }
}