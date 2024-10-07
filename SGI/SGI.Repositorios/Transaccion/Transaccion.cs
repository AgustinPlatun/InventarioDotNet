using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.IO;


namespace SGI.Repositorios;

public class Transaccion { 
    protected int id; 
    private int _productoId; 
    int _cantidad;
    String _tipo; 
    DateTime _fechaTransaccion; 

    public Transaccion(int unId, int idProd, String unTipo,int unaCant, DateTime unafecha) { 
        this.id=unId;
        this._productoId=idProd;
        this.validadorTipo(unTipo);
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
        String rutaArchivo="Producto/productos.txt"; 
        if (this.getTipo().Equals(("salida"))) { 
            try 
                {
                    foreach (String linea in File.ReadLines(rutaArchivo)){
                        var campos = linea.Split(",");
                        if (this._productoId == int.Parse(campos[0])) { 
                            if (int.Parse(campos[4]) >= this._cantidad) { 
                             this._cantidad=unaCant;
                            }
                            else 
                                throw new ArgumentException($" EL STOCK NO ES SUFICIENTE PARA LA CANTIDAD REQUERIDA ");                           
                        }
                    }
                }
                catch 
                {
                    new Exception($" EL ID DEL PRODUCTO NO CORRESPONDE A LA TRANSACCION ");
                }
        }
    }


    private void validadorTipo(String untipo) {
        untipo.ToLower(); 
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