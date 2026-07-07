namespace SGI.Repositorios;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGI.Aplicacion;

public class RepositorioContext : DbContext
{
    public static string ConnectionString { get; set; }
    public RepositorioContext() 
    { 
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }
    }
    public DbSet<Categoria> Categorias { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Producto> Productos { get; set; } = null!;
    public DbSet<Transaccion> Transacciones { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var permisosConverter = new ValueConverter<List<Permiso.Permisos>, string>(
            permisos => string.Join(",", permisos),
            permisosString => string.IsNullOrWhiteSpace(permisosString)
                ? new List<Permiso.Permisos>()
                : permisosString.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => Enum.Parse<Permiso.Permisos>(p))
                    .ToList()
        );

        var permisosComparer = new ValueComparer<List<Permiso.Permisos>>(
            (a, b) => a.SequenceEqual(b),
            permisos => permisos.Aggregate(0, (hash, item) => HashCode.Combine(hash, item.GetHashCode())),
            permisos => permisos.ToList()
        );

        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
        modelBuilder.Entity<Usuario>().Property(u => u.Nombre).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>().Property(u => u.Apellido).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>().Property(u => u.Email).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Usuario>().Property(u => u.Password).HasMaxLength(100).IsRequired();

        modelBuilder.Entity<Usuario>()
            .Property(u => u.Permisos)
            .HasConversion(permisosConverter)
            .Metadata.SetValueComparer(permisosComparer);

        modelBuilder.Entity<Categoria>().ToTable("Categorias");
        modelBuilder.Entity<Categoria>().HasKey(c => c.Id);
        modelBuilder.Entity<Categoria>().Property(c => c.Nombre).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Categoria>().Property(c => c.Descripcion).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Categoria>().Property(c => c.FechaCreacion);
        modelBuilder.Entity<Categoria>().Property(c => c.FechaUltimaModificacion);

        modelBuilder.Entity<Producto>().ToTable("Productos");
        modelBuilder.Entity<Producto>().HasKey(p => p.Id);
        modelBuilder.Entity<Producto>().Property(p => p.Nombre).HasMaxLength(50).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.Descripcion).HasMaxLength(100).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.PrecioUnitario).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.StockDisponible).IsRequired();
        modelBuilder.Entity<Producto>().Property(p => p.FechaCreacion);
        modelBuilder.Entity<Producto>().Property(p => p.FechaUltimaModificacion);
        modelBuilder.Entity<Producto>().Property(p => p.CategoriaId);

        modelBuilder.Entity<Transaccion>().ToTable("Transacciones");
        modelBuilder.Entity<Transaccion>().HasKey(t => t.id);
        modelBuilder.Entity<Transaccion>().Property(t => t._productoId).IsRequired();
        modelBuilder.Entity<Transaccion>().Property(t => t._cantidad).IsRequired();
        modelBuilder.Entity<Transaccion>()
            .Property(t => t._tipo)
            .HasConversion<string>()
            .HasField("_tipo")
            .IsRequired();
        modelBuilder.Entity<Transaccion>().Property(t => t._fechaTransaccion);
    }
}