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
        Conexion cn = new Conexion();
        public bool Login(string strUsuario, string strContraseña)
        {
            try
            {
                string strUsuarioDB = "";
                string strContrasenaDB = "";
                OdbcCommand command = new OdbcCommand("SELECT usuario_login, contraseña_login FROM LOGIN WHERE usuario_login='" + strUsuario + "' AND contraseña_login='" + strContraseña + "' AND estado_login = "+ 1 +" ;", cn.conexion());
                OdbcDataReader reader = command.ExecuteReader();
                reader.Read();
                strUsuarioDB = reader.GetString(0);
                strContrasenaDB = reader.GetString(1);
                reader.Close();
                if (String.IsNullOrEmpty(strUsuarioDB) || String.IsNullOrEmpty(strContrasenaDB))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al consular usuario"+ ex);
                return false;
            }
        }
    }
}
