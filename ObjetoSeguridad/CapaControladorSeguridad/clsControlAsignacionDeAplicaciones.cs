using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModeloSeguridad;

namespace CapaControladorSeguridad
{
    public class clsControlAsignacionDeAplicaciones
    {
        clsAsignacionDeAplicaciones asignacionDeAplicaciones = new clsAsignacionDeAplicaciones();


        public string NombreUsuario(string UserName)
        {
            return asignacionDeAplicaciones.ObtenerNombreUsuario(UserName);
        }

        //Obtener los datos de la tabla perfil
        public OdbcDataReader consulta_perfiles()
        {
            return asignacionDeAplicaciones.consultaperfil();
        }
        //Obtener los datos de la tabla aplicacion.
        public OdbcDataReader consulta_aplicaciones()
        {
            return asignacionDeAplicaciones.consultaaplicacion();
        }

    }
}
