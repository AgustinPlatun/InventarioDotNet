using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.IO;
using System;


namespace SGI.Aplicacion;

public class Transaccion { 
    protected int id; 
    private int _productoId; 
    int _cantidad;
    TipoTransaccion _tipo;   
    DateTime _fechaTransaccion; 

    public Transaccion(int unId, int idProd, TipoTransaccion unTipo,int unaCant, DateTime unafecha) { 
        this.id=unId;
        this._productoId=idProd;
        TransaccionValidador.validadorTipo(unTipo);
        this._tipo=unTipo;
        TransaccionValidador.validarCantidad(unaCant);
        this._tipo=unTipo;
        TransaccionValidador.validarStock(unaCant,idProd,unTipo); 
        this._fechaTransaccion=unafecha;       
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

    public TipoTransaccion getTipo(){ 
        return this._tipo;
    }

    public DateTime getFecha() { 
        return this._fechaTransaccion;
    }    


}