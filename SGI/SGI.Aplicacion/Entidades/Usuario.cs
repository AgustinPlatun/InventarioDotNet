namespace SGI.Aplicacion;
public class Usuario{
    private int _id;
    private string _nombre; 
    private string _apellido; 
    private string _correoelectronico; 
    private string _contr; 
    private List<String> _permisos = new List<string>{"Lectura"}; 
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
    public List<string> permisos{
        get{return _permisos;}
    }

    public string nombre { 
        get { return _nombre ;}
        set { _nombre = nombre; }
    }

        public string apellido { 
        get { return _apellido ;}
        set { _apellido = apellido; }
    }

        public string correoelectronico { 
        get { return _correoelectronico ;}
        set { _correoelectronico = correoelectronico; }
    }
    
        public string contr { 
        get { return _contr ;}
        set { _contr = contr; }
    }

}