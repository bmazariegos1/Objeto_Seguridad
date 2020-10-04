using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaModeloSeguridad
{
     public class ClsModeloBitacora
    {

        Conexion cn = new Conexion();
        String query;

        public int UserSystem; //variable para mantener guardado el usuario 
        public int nombreAplicacion;
        public String accion;
        private string ip = "";

        DateTime now = DateTime.Now; //fecha actual y hora


        public void Insertar() // funcion para insertar en base de datos los movimientos
        {

            string strHostName = string.Empty;
            // Getting Ip address of local machine…
            // First get the host name of local machine.
            strHostName = Dns.GetHostName();
            // Then using host name, get the IP address list..
            IPAddress[] hostIPs = Dns.GetHostAddresses(strHostName);
            for (int i = 0; i < hostIPs.Length; i++)
            {
                ip = hostIPs[i].ToString();
            }
            //label2.Text = "Nombre de la computadora: " + strHostName;

            cn.conexion();

            string fecha = now.ToString("dd/MM/yyyy HH:mm:ss");

            query = "insert into bitacora(fk_idusuario_bitacora, fk_idaplicacion_bitacora, fechahora_bitacora, direccionhost_bitacora, nombrehost_bitacora, accion_bitacora) " +
                "values( " + UserSystem + ", " + nombreAplicacion + ", '" + now + "', '" + ip + "', '" + strHostName + "', '" + accion + "' )";
            SqlCommand comando = new SqlCommand(query);
            comando.ExecuteNonQuery();

        }

    }
}
