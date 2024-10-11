namespace SGI.Aplicacion;
public class Usuario{
    private int _id;
    public Usuario (int id)
    {
        _id = id;
        List<Permisos> permisos;
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

}