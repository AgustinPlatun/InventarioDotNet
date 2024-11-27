using SGI.Aplicacion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SGI.Repositorios
{
    public class RepositorioTransaccion : ITransaccionRepositorio
    {
        public RepositorioTransaccion()
        {
            using (var context = new RepositorioContext())
            {
                context.Database.EnsureCreated(); // Asegura que la base de datos se haya creado
            }
        }

        public void TransaccionAlta(int productoId, int cantidad, TipoTransaccion tipo)
        {
            try
            {
                using (var db = new RepositorioContext()) // Usamos 'using' para asegurar que el contexto se maneje correctamente.
                {
                    // Crear la nueva transacción
                    var transaccion = new Transaccion(productoId, tipo, cantidad, DateTime.Now);
                    db.Transacciones.Add(transaccion);  // Añadir la transacción a la tabla Transacciones

                    // Buscar el producto relacionado con la transacción
                    Producto p = db.Productos.FirstOrDefault(producto => producto.Id == productoId);
                    if (p == null)
                    {
                        throw new Exception($"Producto con ID {productoId} no encontrado.");
                    }

                    // Actualización del stock según el tipo de transacción
                    if (tipo == TipoTransaccion.entrada)
                    {
                        p.StockDisponible += cantidad;  // Incrementar el stock si es una entrada
                    }
                    else if (tipo == TipoTransaccion.salida)
                    {
                        p.StockDisponible -= cantidad;  // Decrementar el stock si es una salida
                    }
                    else
                    {
                        throw new Exception($"Tipo de transacción no válido.");
                    }

                    // Actualizar la fecha de modificación del producto
                    p.actualizarFechaMod();

                    // Guardar cambios en la base de datos
                    db.SaveChanges();  // Guarda los cambios en la base de datos
                }
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Error al agregar la transacción: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public void TransaccionBaja(int id)
        {
            try
            {
                using (var db = new RepositorioContext()) // Usamos 'using' para asegurar que el contexto se maneje correctamente.
                {
                    // Buscar la transacción por su ID
                    Transaccion t = db.Transacciones.FirstOrDefault(trans => trans.id == id); // Usar Id en lugar de _id
                    if (t == null)
                    {
                        throw new Exception($"Transacción con ID {id} no encontrada.");
                    }

                    // Buscar el producto relacionado con la transacción
                    Producto p = db.Productos.FirstOrDefault(producto => producto.Id == t._productoId); // Usar ProductoId en lugar de _productoId
                    if (p == null)
                    {
                        throw new Exception($"Producto con ID {t._productoId} no encontrado.");
                    }

                    // Actualizar el stock dependiendo del tipo de transacción
                    if (t._tipo == TipoTransaccion.entrada)
                    {
                        p.StockDisponible -= t._cantidad;  // Decrementar el stock si la transacción es de entrada
                    }
                    else if (t._tipo == TipoTransaccion.salida)
                    {
                        p.StockDisponible += t._cantidad;  // Incrementar el stock si la transacción es de salida
                    }
                    else
                    {
                        throw new Exception("Tipo de transacción no válido.");
                    }

                    // Actualizar la fecha de modificación del producto
                    p.actualizarFechaMod();

                    // Eliminar la transacción
                    db.Transacciones.Remove(t);

                    // Guardar los cambios en la base de datos
                    db.SaveChanges();  // Guarda los cambios en la base de datos
                }
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Error al dar de baja la transacción: {dbEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Métodos adicionales para listar y buscar transacciones

        public List<Transaccion> ListarTransacciones()
        {
            using (var db = new RepositorioContext())
            {
                return db.Transacciones.ToList();  // Lista todas las transacciones
            }
        }

        public Transaccion BuscarTransaccion(int id)
        {
            using (var db = new RepositorioContext())
            {
                return db.Transacciones.FirstOrDefault(t => t.id == id);  // Buscar una transacción por su ID
            }
        }

        public List<Transaccion> ListarTransaccionesEntreFechas(DateTime f1, DateTime f2)
        {
            using (var db = new RepositorioContext())
            {
                return db.Transacciones
                    .Where(t => t._fechaTransaccion >= f1 && t._fechaTransaccion <= f2)
                    .ToList();  // Listar transacciones entre dos fechas
            }
        }
    }
}

