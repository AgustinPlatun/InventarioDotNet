using Microsoft.EntityFrameworkCore;
using SGI.Aplicacion; 

namespace Usuario; 

public class UsuarioContext : DbContext 
{ 
    public DbSet <Usuario> Usuarios {get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Usuario>().HasKey(u => u.IdUsuario);
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Nombre)columna
            .HasMaxLength(100) //establece el maximo
            .IsRequired(true); //establece que no puede ser null
        modelBuilder.Entity<Usuario>()
            .Property(u => u.apellido)columna
            .HasMaxLength(100)
            .IsRequired(true);
        modelBuilder.Entity<Usuario>()
            .Property(u => u.correoelectronico)columna
            .HasMaxLength(100)
            .IsRequired(true);
        modelBuilder.Entity<Usuario>()
            .Property(u => u.contr)columna
            .HasMaxLength(20)
            .IsRequired(true);
    }
}