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
        public OdbcDataReader consulta_perfiles_asignados(string UserName)
        {
            return asignacionDeAplicaciones.consultaperfilasignado(UserName);
        }
        //Obtener los datos de la tabla aplicacion.
        public OdbcDataReader consulta_aplicaciones_asignadas(string UserName)
        {
            return asignacionDeAplicaciones.consultaaplicacionasignada(UserName);
        }
        public OdbcDataReader consulta_adb(string UserName, string Aplicacion)
        {
            return asignacionDeAplicaciones.consultadb(UserName, Aplicacion);
        }
        public OdbcDataReader consulta_adbper(string UserName, string Aplicacion)
        {
            return asignacionDeAplicaciones.consultadbper(UserName, Aplicacion);
        }
    }
}
