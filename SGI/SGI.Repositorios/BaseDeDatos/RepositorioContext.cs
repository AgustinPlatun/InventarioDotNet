namespace SGI.Repositorios;

using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using SGI.Aplicacion;

public class RepositorioContext: DbContext
{
    
    public DbSet<Categoria> Categorias{get; set;}

    public DbSet<Usuario> Usuarios{get; set;}

    public DbSet<Producto> Productos { get; set;}

    public DbSet <Transaccion> Transacciones {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=Repositorio.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Usuarios
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario); // Definiendo la clave primaria
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Nombre) //establece la variable que va a ocupar esa columna
            .HasMaxLength(100) //establece el maximo
            .IsRequired(true); //establece que no puede ser null

        modelBuilder.Entity<Usuario>().Property(u => u.Apellido).HasMaxLength(100).IsRequired(true);
        modelBuilder.Entity<Usuario>().Property(u => u.Email).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>().Property(u => u.Password).HasMaxLength(100).IsRequired();
        // modelBuilder.Entity<Usuario>()
        // .Property(u => u.Permisos)
        // .HasConversion(
        //     permisos => permisos != null ? string.Join(",", permisos.Select(p => p.ToString())) : "",
        //     permisosString => permisosString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());

        // Categoria
        modelBuilder.Entity<Categoria>().ToTable("Categorias");
        modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
        modelBuilder.Entity<Categoria>()
            .Property(c => c.Nombre)
            .HasMaxLength(100)
            .IsRequired(true);
        modelBuilder.Entity<Categoria>().Property(c => c.Descripcion)
            .HasMaxLength(100)
            .IsRequired(true);
        modelBuilder.Entity<Categoria>().Property(c => c.FechaCreacion);
        modelBuilder.Entity<Categoria>().Property(c => c.FechaUltimaModificacion);

        // Productos
        modelBuilder.Entity<Producto>().ToTable("Productos");
        modelBuilder.Entity<Producto>().HasKey(p => p.Id); // Definir la clave primaria
        modelBuilder.Entity<Producto>().Property(p => p.Nombre).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.Descripcion).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.PrecioUnitario).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.StockDisponible).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.FechaCreacion);
        modelBuilder.Entity<Producto>().Property(p => p.FechaUltimaModificacion);
        modelBuilder.Entity<Producto>().Property(p => p.CategoriaId);   
        //Transaccion
        modelBuilder.Entity<Transaccion>().ToTable("Transacciones");
        modelBuilder.Entity<Transaccion>().HasKey(t => t.id); 
        modelBuilder.Entity<Transaccion>().Property(t => t.id).ValueGeneratedOnAdd(); 
        modelBuilder.Entity<Transaccion>().Property(t => t._productoId).IsRequired();
        modelBuilder.Entity<Transaccion>().Property(t => t._cantidad).IsRequired(); 
        modelBuilder.Entity<Transaccion>().Property(t => t._tipo).IsRequired();  // El tipo de transacción es obligatorio
        modelBuilder.Entity<Transaccion>().Property(t => t._fechaTransaccion);
    }
}