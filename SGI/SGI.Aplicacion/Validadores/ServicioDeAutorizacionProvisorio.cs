using System.Collections.Generic;
namespace SGI.Aplicacion;
public class ServicioDeAutorizacionProvisorio : IServicioDeAutorizacion{
    public bool PoseeElPermiso (int idUsuario)
    {
        
        return idUsuario == 1;
    }
}