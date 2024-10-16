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
        int categoriaId;

        public Producto(int id, string nombre, string descripcion, double precioUnitario, int stockDisponible, int categoriaId)
        {
            this.id = id;
            ProductoValidador.ValidarNombre(nombre);
            this.nombre = nombre;
            this.descripcion = descripcion;
            ProductoValidador.ValidarPrecioUnitario(precioUnitario);
            this.precioUnitario = precioUnitario;
            ProductoValidador.ValidarStockDisponible(stockDisponible);
            this.stockDisponible = stockDisponible;
            this.categoriaId = categoriaId;
            this.fechaCreacion = DateTime.Now;
            this.fechaUltimaModificacion = DateTime.Now;
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
                ProductoValidador.ValidarNombre(nombre);
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
                ProductoValidador.ValidarPrecioUnitario(value);
                precioUnitario = value;
                fechaUltimaModificacion = DateTime.Now;
            }
        }

        public int StockDisponible
        {
            get { return stockDisponible; }
            set
            {
                ProductoValidador.ValidarStockDisponible(value);
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
    }
}
