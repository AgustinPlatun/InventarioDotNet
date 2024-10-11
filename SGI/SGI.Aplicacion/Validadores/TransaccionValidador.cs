namespace SGI.Aplicacion;

public static class TransaccionValidador { 
    
      public static void validarCantidad(int unaCant) {
        if (unaCant < 0) 
            throw new ArgumentException (" NO SE CUMPLEN LAS REGLAS DE VALIDACION  : STOCK < 0");
    }
    
    public static void validarStock(int unaCant,int IDproducto ,TipoTransaccion tipo) {
    string rutaArchivo = "../SGI.Repositorios/listadoProductos.txt";

    if (tipo==TipoTransaccion.salida) {
        using (StreamReader reader = new StreamReader(rutaArchivo)) {   
            bool productoEncontrado = false;
            try {
                while (!reader.EndOfStream) {
                    string linea = reader.ReadLine();
                    string[] campos = linea.Split(",");

                    if (IDproducto == int.Parse(campos[0])) {
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



    public static void validadorTipo(TipoTransaccion untipo) {
        if (!untipo.Equals(TipoTransaccion.entrada)&&!untipo.Equals(TipoTransaccion.salida)){ 
            throw new ArgumentException (" NO SE INGRESO EL TIPO DE TRANSACCION (SALIDA O ENTRADA)"); 
        }
}

}