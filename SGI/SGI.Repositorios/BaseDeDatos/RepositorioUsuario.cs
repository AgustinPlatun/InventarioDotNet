using SGI.Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace SGI.Repositorios;

public class RepositorioUsuario : IUsuarioRepositorio
{
    public RepositorioUsuario(){
        using (var context = new RepositorioContext()){
            context.Database.EnsureCreated(); //si la base de datos no existe se crea y de  vuelve true
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand()){
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }
    }

        public int? UsuarioAlta(string nombre, string apellido, string email, string password){
        using (var db = new RepositorioContext()){
            var usuario = new Usuario(nombre,apellido, email, password);
            db.Add(usuario);//se agregará realmente con el db.SaveChanges()
            db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
            return usuario.IdUsuario;
        }
    }

    public void UsuarioBaja(string email){
        using (var db = new RepositorioContext()){
            var usuarioABorrar = db.Usuarios.FirstOrDefault(u => u.Email!.ToLower() == email.ToLower()); 
            if (usuarioABorrar != null){
                db.Remove(usuarioABorrar); //se borra realmente con el db.SaveChanges()
                db.SaveChanges();//actualiza la base de datos. SQlite establece el valor de usuario.Id
            }
        }
    }

        public void UsuarioModicacion(int? idUsuario,string nombre, string apellido, string email, string password, List<string>? permisos){
        using(var db = new RepositorioContext()){
            var usuarioAModificar = db.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            if(usuarioAModificar != null){
                usuarioAModificar.Nombre = nombre;
                usuarioAModificar.Apellido = apellido;
                usuarioAModificar.Email = email;
                usuarioAModificar.Password = password;
                usuarioAModificar.Permisos = permisos;

                db.SaveChanges();
            }
        }   
    }   
}