using System;

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
        int categoriaId;

        public Producto(int id, string nombre, string descripcion, double precioUnitario, int stockDisponible)
        {
            this.id = id;
            ValidarNombre(nombre);
            this.nombre = nombre;
            this.descripcion = descripcion;
            ValidarPrecioUnitario(precioUnitario);
            this.precioUnitario = precioUnitario;
            ValidarStockDisponible(stockDisponible);
            this.stockDisponible = stockDisponible;
            this.fechaCreacion = DateTime.Now;
            this.fechaUltimaModificacion = DateTime.Now;
        }
        public Producto(int id, string nombre, string descripcion, double precioUnitario, int stockDisponible,DateTime fechaCreacion,DateTime fechaUltimaModificacion,int categoriaId)
        {
            this.id = id;
            ValidarNombre(nombre);
            this.nombre = nombre;
            this.descripcion = descripcion;
            ValidarPrecioUnitario(precioUnitario);
            this.precioUnitario = precioUnitario;
            ValidarStockDisponible(stockDisponible);
            this.stockDisponible = stockDisponible;
            this.fechaCreacion = fechaCreacion;
            this.fechaUltimaModificacion = fechaUltimaModificacion;
            this.categoriaId = categoriaId;
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
                ValidarNombre(value);
                nombre = value;
                fechaUltimaModificacion = DateTime.Now;
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set 
            { 
                descripcion = value;
                fechaUltimaModificacion = DateTime.Now;
            }
        }

        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set
            {
                ValidarPrecioUnitario(value);
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

        public int CategoriaId
        {
            get { return categoriaId; }
            set 
            { 
                categoriaId = value;
                fechaUltimaModificacion = DateTime.Now; 
            }
        }

        private void ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre NO puede estar vacío");
            }
        }

        private void ValidarPrecioUnitario(double precioUnitario)
        {
            if (precioUnitario < 0)
            {
                throw new ArgumentException("El precio por unidad NO PUEDE ser menor a 0");
            }
        }

        private void ValidarStockDisponible(int stockDisponible)
        {
            if (stockDisponible < 0)
            {
                throw new ArgumentException("El stock disponible NO PUEDE ser menor a 0");
            }
        }

        public void Imprimir()
        {
            Console.WriteLine($"ID: {id}, Nombre: {nombre}, Descripción: {descripcion}, Precio: {precioUnitario}, Stock: {stockDisponible}");
        }
    }
}
