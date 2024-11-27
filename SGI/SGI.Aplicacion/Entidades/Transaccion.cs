using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.IO;
using System;


namespace SGI.Aplicacion;

public class Transaccion { 
    public int id; 
    public int _productoId; 
    public int _cantidad;
    public TipoTransaccion _tipo;   
    public DateTime _fechaTransaccion; 

    public Transaccion(int idProd, TipoTransaccion unTipo,int unaCant, DateTime unafecha) { 
        this._productoId=idProd;
        this._tipo=unTipo;
        this._tipo=unTipo;
        this._fechaTransaccion=unafecha;       
    }

    public Transaccion() { 
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