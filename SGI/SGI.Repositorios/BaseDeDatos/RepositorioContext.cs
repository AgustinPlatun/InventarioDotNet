namespace SGI.Repositorios;

using Microsoft.EntityFrameworkCore;
using SGI.Aplicacion;

public class RepositorioContext: DbContext{
    public DbSet<Usuario> Usuarios{get; set;}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("data source=Repositorio.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
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
        modelBuilder.Entity<Usuario>()
        .Property(u => u.Permisos)
        .HasConversion(
            permisos => permisos != null ? string.Join(",", permisos.Select(p => p.ToString())) : "",
            permisosString => permisosString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .ToList()
        );
    }
}