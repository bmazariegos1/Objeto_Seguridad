using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaModeloSeguridad
{
    public class clsAsignacionDeAplicaciones
    {
        clsConexion cn = new clsConexion();

        //funcion para obtener el nombre de usuario
        public string ObtenerNombreUsuario(string UserName)
        {
            string NombreUsuario = "";
            try
            {
                OdbcCommand command = new OdbcCommand("select LO.nombreCompleto_login from LOGIN LO where LO.usuario_login ='" + UserName + "';", cn.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                reader.Read();
                NombreUsuario = reader.GetString(0);
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("CapaModelo Error al consular ObtenerNombreUsuario:  " + ex);
            }
            return NombreUsuario;
        }

        //Llenar las listas de permisos y aplicaciones
        public OdbcDataReader consultaperfil()
        {
            try
            {
                string strConsulta = "SELECT nombre_perfil FROM perfil where estado_perfil = 1;";
                OdbcCommand command = new OdbcCommand(strConsulta, cn.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en la vista de contenido.");
                Console.WriteLine("CapaModelo Error al consular 'consultaPerfil':  " + ex);
                return null;
            }
        }
        public OdbcDataReader consultaaplicacion()
        {
            try
            {
                string strConsulta = "SELECT nombre_aplicacion FROM aplicacion where estado_aplicacion = 1;";
                OdbcCommand command = new OdbcCommand(strConsulta, cn.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error en la vista de contenido.");
                Console.WriteLine("CapaModelo Error al consular 'consultaAplicacion':  " + ex);
                return null;
            }
        }
    }
}
