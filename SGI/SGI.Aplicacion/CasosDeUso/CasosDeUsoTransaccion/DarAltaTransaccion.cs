namespace SGI.Aplicacion;
public class DarAltaTransaccion() : ICasosDeUso {
    public void Lanzar(int idUsuario) { 
    Console.Write("Ingresar ID de la transaccion : ");String id = Console.ReadLine() ?? "0";
    Console.Write("Ingresar ID del PRODUCTO : ");String idProd = Console.ReadLine() ?? "0";
    Console.Write("Ingresar TIPO DE TRANSACCION (1 = entrada -- 0 = salida) : ");String tipo= Console.ReadLine() ?? "";
    Console.Write("Ingresar cantidad del producto : "); String cant = Console.ReadLine() ?? "0"; 
    DateTime fecha = DateTime.Now;  
    TipoTransaccion tipoenum; 
    if (tipo == "1") {
         tipoenum = TipoTransaccion.entrada;
     }
     else 
        if (tipo == "0") {
         tipoenum = TipoTransaccion.salida;
     }
     else  {
        tipoenum = (TipoTransaccion)Enum.Parse(typeof(TipoTransaccion), tipo);
        TransaccionValidador.validadorTipo(tipoenum);
     }

    Transaccion t = new Transaccion (int.Parse(id), int.Parse(idProd), tipoenum, int.Parse(cant),fecha); 
    
    string documentoTransaccion ="../SGI.Repositorios/listadoTransacciones.txt";

    using (StreamWriter writer = new StreamWriter(documentoTransaccion,true)) { 
        writer.WriteLine($"{t.getId()},{t.getProductoId()},{t.getTipo()},{t.getCantidad()},{t.getFecha()}");
    }

    string documentoProducto ="../SGI.Repositorios/listadoProductos.txt";
    bool seactualizo = false; 
   try
            {
                var lineas = File.ReadAllLines(documentoProducto).ToList();

                var lineasactualizadas = lineas.Select(l =>
                {
                    var campos = l.Split(",");
                    if (campos.Length > 6 && campos[0] == idProd)
                    {
                        if (int.TryParse(campos[4], out int stock))
                        {
                            if (tipoenum == TipoTransaccion.entrada)
                            {
                                campos[4] = (stock + int.Parse(cant)).ToString();
                            }
                            else if (tipoenum == TipoTransaccion.salida)
                            {
                                if (stock >= int.Parse(cant))
                                {
                                    campos[4] = (stock - int.Parse(cant)).ToString();
                                }
                                else
                                {
                                    Console.WriteLine($"No hay suficiente stock para realizar la salida del producto con ID {idProd}.");
                                    return l; // Retornar la línea original si no se puede realizar la salida
                                }
                            }
                            campos[6] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            seactualizo = true;
                        }
                    }
                    return string.Join(",", campos);
                }).ToList();

                if (seactualizo)
                {
                    File.WriteAllLines(documentoProducto, lineasactualizadas);
                    Console.WriteLine($"El stock del producto con ID {idProd} fue actualizado correctamente!");
                }
                else
                {
                    throw new ArgumentException($"El PRODUCTO CON ID {idProd} NO FUE ENCONTRADO O NO EXISTE EN EL SISTEMA");
                }
            }
            catch (Exception ex)
            {
                throw new ($"Se produjo un error en la lectura del archivo : {ex.Message}");
                
            }
        }
    }