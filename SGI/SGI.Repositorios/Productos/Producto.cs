using System;

namespace SGI.Repositorios
{
    public class Producto
    {
        // Campos privados
        private int id;
        private string nombre;
        private string descripcion;
        private double precioUnitario;
        private int stockDisponible;
        private DateTime fechaCreacion;
        private DateTime fechaUltimaModificacion;
        private int categoriaId;

        // Constructor
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
            this.fechaCreacion = DateTime.Now; // Asigna la fecha de creación actual
            this.fechaUltimaModificacion = DateTime.Now; // Asigna la fecha de modificación actual
        }

        // Propiedades públicas
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
                fechaUltimaModificacion = DateTime.Now; // Actualiza la fecha de modificación
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set
            {
                ValidarPrecioUnitario(value);
                precioUnitario = value;
                fechaUltimaModificacion = DateTime.Now; // Actualiza la fecha de modificación
            }
        }

        public int StockDisponible
        {
            get { return stockDisponible; }
            set
            {
                ValidarStockDisponible(value);
                stockDisponible = value;
                fechaUltimaModificacion = DateTime.Now; // Actualiza la fecha de modificación
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
            set { categoriaId = value; }
        }

        // Métodos de validación
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

        // Método para imprimir información del producto
        public void Imprimir()
        {
            Console.WriteLine($"ID: {id}, Nombre: {nombre}, Descripción: {descripcion}, Precio: {precioUnitario}, Stock: {stockDisponible}");
        }
    }
}
