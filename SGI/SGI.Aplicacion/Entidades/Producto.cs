using System;
using SGI.Aplicacion;

namespace SGI.Aplicacion
{
    public class Producto
    {
        int id;
        string nombre;
        string descripcion;
        double precioUnitario;
        int stockDisponible;
        DateTime fechaCreacion;
        DateTime fechaUltimaModificacion;
        public int categoriaId;

        public Producto(int id, string nombre, string descripcion, double precioUnitario, int stockDisponible, int categoriaId)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precioUnitario = precioUnitario;
            this.stockDisponible = stockDisponible;
            this.categoriaId = categoriaId;
            this.fechaCreacion = DateTime.Now;
            this.fechaUltimaModificacion = DateTime.Now;
        }
        public Producto(string nombre, string descripcion, double precioUnitario, int stockDisponible)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precioUnitario = precioUnitario;
            this.stockDisponible = stockDisponible;
            this.fechaCreacion = DateTime.Now;
            this.fechaUltimaModificacion = DateTime.Now;
            this.categoriaId=0;
        }
        public Producto(string nombre, string descripcion, double precioUnitario, int stockDisponible, int categoriaId)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precioUnitario = precioUnitario;
            this.stockDisponible = stockDisponible;
            this.fechaCreacion = DateTime.Now;
            this.fechaUltimaModificacion = DateTime.Now;
            this.categoriaId=0;
        }

        public int Id
        {
            get { return id; }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
            }
        }
        public int CategoriaId
        {
            get { return categoriaId; }
            set
            {
                categoriaId = value;
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set 
            { 
                descripcion = value;
            }
        }

        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set
            {
                precioUnitario = value;
                fechaUltimaModificacion = DateTime.Now;
            }
        }

        public int StockDisponible
        {
            get { return stockDisponible; }
            set
            {
                stockDisponible = value;
                fechaUltimaModificacion = DateTime.Now;
            }
        }

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
        }

        public DateTime FechaUltimaModificacion
        {
            get { return fechaUltimaModificacion; }
        }

        public void Imprimir()
        {
            Console.WriteLine($"ID: {id}, Nombre: {nombre}, Descripción: {descripcion}, Precio: {precioUnitario}, Stock: {stockDisponible}");
        }

        public void actualizarFechaMod() { 
            this.fechaUltimaModificacion=DateTime.Now;
        }
    }
}
