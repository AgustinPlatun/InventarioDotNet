using System;
namespace SGI.Aplicacion;

public class DarBajaTransaccion() : ICasosDeUso {
    public void Lanzar(int idUsuario){
        Console.Write("Ingresar id de la transaccion a encontrar :");String id = Console.ReadLine() ?? "0";
        string documentoTransaccion = "../SGI.Repositorios/listadoTransacciones.txt";
           var lineas = File.ReadAllLines(documentoTransaccion).Where(linea => 
                     { var campos = linea.Split(",");
                        return campos.Length > 0 && campos[0] != id;}).ToList();
    if (lineas.Count < File.ReadAllLines(documentoTransaccion).Length) {
        File.WriteAllLines(documentoTransaccion, lineas);
        Console.WriteLine($"La transacción con ID {id} fue dada de baja satisfactoriamente."); }
    else{ 
        throw new ArgumentException($"LA TRANSACCION DE ID {id} NO EXISTE O NO FUE CARGADA EN LA LISTA.");}
    }
    
}