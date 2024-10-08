using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.IO;
using System;


namespace SGI.Repositorios;

public class Transaccion { 
    protected int id; 
    private int _productoId; 
    int _cantidad;
    String _tipo = "No definido."; 
    DateTime _fechaTransaccion; 

    public Transaccion(int unId, int idProd, String unTipo,int unaCant, DateTime unafecha) { 
        this.id=unId;
        this._productoId=idProd;
        this.validadorTipo(unTipo.ToLower());
        this.validarCantidad(unaCant); 
        this.validarStock(unaCant);
        this._fechaTransaccion=unafecha;       
    }
    private void validarCantidad(int unaCant) {
        if (unaCant > 0) 
            this._cantidad=unaCant;
        else 
            throw new ValidationException (" NO SE CUMPLEN LAS REGLAS DE VALIDACION  : STOCK < 0");
    }
    private void validarStock(int unaCant) {
    string rutaArchivo = "../SGI.Repositorios/Productos/Productos.txt";

    if (this.getTipo().Equals("salida")) {
        using (StreamReader reader = new StreamReader(rutaArchivo)) {
            bool productoEncontrado = false;

            try {
                while (!reader.EndOfStream) {
                    string linea = reader.ReadLine();
                    string[] campos = linea.Split(",");

                    if (this._productoId == int.Parse(campos[0])) {
                        productoEncontrado = true;
                        if (int.Parse(campos[4]) < unaCant) {
                            throw new ArgumentException("EL STOCK NO ES SUFICIENTE PARA LA CANTIDAD REQUERIDA ");
                        }
                        return;
                    }
                }

                if (!productoEncontrado) {
                    throw new ArgumentException("EL ID DEL PRODUCTO NO CORRESPONDE A LA TRANSACCION");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}



    private void validadorTipo(String untipo) {
        if (!untipo.Equals("salida")&&!untipo.Equals("entrada")){ 
            throw new ArgumentException (" NO SE INGRESO EL TIPO DE TRANSACCION (SALIDA O ENTRADA)"); 
        }
        else
            this._tipo=untipo;
    }


    public int getId() { 
        return this.id; 
    }

    public int getProductoId() { 
        return this._productoId;
    }

    public int getCantidad() { 
        return this._cantidad;
    }

    public String getTipo(){ 
        return this._tipo;
    }

    public DateTime getFecha() { 
        return this._fechaTransaccion;
    }    


}