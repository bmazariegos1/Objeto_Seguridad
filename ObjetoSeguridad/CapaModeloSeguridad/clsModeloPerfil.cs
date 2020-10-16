using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaModeloSeguridad
{
    public class clsModeloPerfil
    {
        clsConexion cn = new clsConexion();
        OdbcCommand Comm;

        public int Login(string strUsuario, string strContrasena)
        {
            try
            {
                string strUsuarioDB = "";
                string strContrasenaDB = "";
               Comm = new OdbcCommand("SELECT usuario_login, contraseña_login FROM login WHERE usuario_login ='" + strUsuario + "' AND contraseña_login ='" + strContrasena + "' AND estado_login = 1 ;", cn.conexion());
                OdbcDataReader reader = Comm.ExecuteReader();
                reader.Read();
                strUsuarioDB = reader.GetString(0);
                strContrasenaDB = reader.GetString(1);
                reader.Close();
                if (String.IsNullOrEmpty(strUsuarioDB) || String.IsNullOrEmpty(strContrasenaDB))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CapaModelo Error al consular usuario:  "+ ex);
                return 0;
            }
        }
        public OdbcDataReader Modificar(string Consulta)
        {
            try
            {
                Comm = new OdbcCommand(Consulta, cn.conexion());
                OdbcDataReader mostrar = Comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception Error)
            {
                Console.WriteLine("Error en modelo-modificar ", Error);
                return null;
            }
        }
    }
}
