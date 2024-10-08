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
        String rutaArchivo= "../SGI.Repositorios/Productos/Productos.txt"; 
        if (this.getTipo().Equals(("salida"))) 
        { 
            try 
            {
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {    
                    while (!reader.EndOfStream)
                    {
                        String line = reader.ReadLine();
                        String []campos = line.Split(",");
                        int cantAct = int.Parse(campos[4]);
                        Console.WriteLine($"cantidad actual: {cantAct}");
                        if (this._productoId == int.Parse(campos[0])) 
                        { 
                            if (cantAct >= unaCant) 
                            {
                             this._cantidad=unaCant;
                             Console.WriteLine($"{unaCant}");
                            }
                            else 
                            {
                                    throw new ArgumentException($" EL STOCK NO ES SUFICIENTE PARA LA CANTIDAD REQUERIDA ");                           
                            }
                        }
                    }
                }
            }
            catch 
                {
                    throw new ArgumentException($" EL ID DEL PRODUCTO NO CORRESPONDE A LA TRANSACCION ");
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