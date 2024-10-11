using System.Linq.Expressions;

namespace SGI.Aplicacion; 

public  class ListarTransacciones() : ICasosDeUso {
   public void Lanzar(int idUsuario) { 
        string documentoTransaccion ="../SGI.Repositorios/listadoTransacciones.txt";
        try {
        var lineas = File.ReadAllLines(documentoTransaccion);
        foreach (var l in lineas) {
            Console.WriteLine(l);
        }
    }
        catch (Exception ex) { 
            Console.WriteLine($" Se produjo un error al leer el archivo {ex.Message} ");
        }
    }     

}