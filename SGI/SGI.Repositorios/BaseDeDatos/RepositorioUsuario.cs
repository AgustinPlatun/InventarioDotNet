using SGI.Aplicacion;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;

namespace SGI.Repositorios;

public class RepositorioUsuario : IUsuarioRepositorio
{
    public RepositorioUsuario()
    {
        using (var context = new RepositorioContext())
        {
            context.Database.EnsureCreated(); //si la base de datos no existe se crea y de  vuelve true
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }
    }

        public int? UsuarioAlta(string nombre, string apellido, string email, string password)
        {
        using (var db = new RepositorioContext())
        {
            var usuario = new Usuario(nombre,apellido, email, password);
            db.Add(usuario);//se agregará realmente con el db.SaveChanges()
            db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
            return usuario.IdUsuario;
        }
    }

    public void UsuarioBaja(string email)
    {
        using (var db = new RepositorioContext())
        {
            var usuarioABorrar = db.Usuarios.FirstOrDefault(u => u.Email!.ToLower() == email.ToLower()); 
            if (usuarioABorrar != null)
            {
                db.Remove(usuarioABorrar); //se borra realmente con el db.SaveChanges()
                db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
            }
        }
    }

    public void UsuarioModificacion(int? idUsuario,string nombre, string apellido, string email, string password)
    {
        using(var db = new RepositorioContext())
        {
            
            var usuarioAModificar = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            if(usuarioAModificar != null)
            {
                usuarioAModificar.Nombre = nombre;
                usuarioAModificar.Apellido = apellido;
                db.SaveChanges();
            }else
            {
                throw new RepositorioException("El usuario no existe.");
            }
        }
    }  
    public List<Usuario> MostrarUsuarios()
    {
        using (var db = new RepositorioContext())
        {
            var usuarios = db.Usuarios.ToList();
            return usuarios;
        }
    }

    public bool EmailRepetido(string? email)
    {
        bool repetido=false;
        using (var db = new RepositorioContext())
        {
            var usuario = db.Usuarios.FirstOrDefault(u => u.Email!.ToLower() == email!.ToLower()); 
            if (usuario == null)
            {
                repetido=true;
            }
            return repetido;
        }
    }

    public Usuario UsuarioInicioDeSesion(string email, string password)
    { 
        using(var db = new RepositorioContext())
        {
            var usuario = db.Usuarios.FirstOrDefault(u => u.Email!.ToLower() == email.ToLower());
            if(usuario != null)
            {
                if (usuario.Password == password)
                {
                    return usuario;
                }else
                {
                    throw new Exception("La contraseña ingresada no corresponde con el email ingresado");
                }
            }else
            {
                throw new Exception("El email ingresado no existe en el repositorio");
            }
        }
    }

        public bool UsuarioValidarPermiso(Permiso.Permisos permiso, int idUsuario)
        {
        using(var db = new RepositorioContext())
        {
            var usuario = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario); //no puede enviar null, ya que es la id del usuario utilizando el sistema
            if(usuario != null)
            {
                if(usuario.Permisos != null)
                {
                    return usuario.Permisos.Contains(permiso);
                }else
                {
                    return false;
                }
            } 
            return false; //para emergencias 
        }
    }
        public void agregarPermisos(List<Permiso.Permisos> permiso,int idUsuario)
        {
            using (var db = new RepositorioContext())
            {
                var usuario = db.Usuarios.FirstOrDefault(us => us.IdUsuario == idUsuario);
                if (usuario == null)
                {
                    throw new Exception("Hubo un problema con la busqueda del usuario.");
                }
                usuario.Permisos = permiso;

                db.SaveChanges();
            }
        }
        public void eliminarPermisos(List<Permiso.Permisos> permiso, int idUsuario)
        {
            using (var db = new RepositorioContext())
            {
                var usuario = db.Usuarios.FirstOrDefault(us => us.IdUsuario == idUsuario);
                if (usuario == null)
                {
                    throw new Exception("Hubo un problema con la busqueda del usuario.");
                }
                usuario.Permisos = permiso;
                db.SaveChanges();
            }
        }
}