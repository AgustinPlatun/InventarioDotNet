using System.Collections.Generic;
public class ServicioDeAutorizacionProvisorio : IServicioDeAutorizacion{
    public bool PoseeElPermiso (int idUsuario)
    {
        if (idUsuario == 1) 
        {
            return true;
        } else 
        {
        return false;
        }
    }
}