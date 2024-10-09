namespace SGI.Repositorios;
public class Usuario{
    private int _id;
    public Usuario (int id)
    {
        _id = id;
    }


    public int Id {
        get 
        {
            return _id;
        }
        set
        {
            _id = Id;
        }
    }

    public void realizarOperaciones()
    {
        bool validacion = UsuarioValidador.validarUsuario(_id);
        UsuarioValidador.permisosException(validacion);
        
        Menu menuOpciones = new Menu();
        while(!menuOpciones.opcion.Equals("0"))
        {
            menuOpciones.invocarMenu();
            menuOpciones.opcion = Console.ReadLine() ?? "999";
            menuOpciones.elegirOpciones();
        }
    }

}