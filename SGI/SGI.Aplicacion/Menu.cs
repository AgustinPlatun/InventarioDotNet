using System;
namespace SGI.Aplicacion;
using SGI.Aplicacion;
public class Menu{
    private string _opcion = "999";
    Usuario usuario;
    ICasosDeUso[] opciones = new ICasosDeUso[]
    {
        new DarAltaProducto(),
        new DarBajaProducto(),
        new ModificarProducto(),
        new DarAltaCategoria(),
        new DarBajaCategoria(),
        new ModificarCategoria(),
        new DarAltaTransaccion(),
        new DarBajaTransaccion(),
        new ListarTransacciones(),
        new ListarTransaccionesEntreFechas()
    };

    public string _Opcion
        {
            get { return _opcion; }
        }

    public void invocarMenu(){
        Console.WriteLine("-------------------------------");
        Console.WriteLine("0. Salir");
        for (int i = 0; i < opciones.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {opciones[i].GetType().Name}");
        }
    }

    public void elegirOpcion(){
        this._opcion = Console.ReadLine();
        int seleccion = int.Parse(_opcion);
        if(seleccion != 0){
            ICasosDeUso opcionSeleccionada = opciones[seleccion - 1];
            opcionSeleccionada.Lanzar(usuario.Id);
        }else{
            Console.WriteLine("Hasta Luego !");
        }
        
    }

    public void ingresarUsuario(){
        Console.Write("Ingresar id de usuario :");
        string id = Console.ReadLine();
        this.usuario = new Usuario(int.Parse(id));
    }
    }