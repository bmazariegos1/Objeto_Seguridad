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
        public OdbcDataReader consultaperfilasignado(string txtUsuario)
        {
            try
            {
                string strConsulta = "select P.nombre_perfil FROM PERFIL P INNER JOIN PERFILUSUARIO PU on P.pk_id_perfil = PU.fk_idperfil_perfilusuario INNER JOIN LOGIN LO on PU.fk_idusuario_perfilusuario = LO.pk_id_login where LO.usuario_login = '" + txtUsuario + "';";

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
        public OdbcDataReader consultaaplicacionasignada(string txtUsuario)
        {
            try
            {
                string strConsulta = "select AP.nombre_aplicacion FROM APLICACION AP INNER JOIN APLICACIONUSUARIO APU on AP.pk_id_aplicacion = APU.fk_idaplicacion_aplicacionusuario INNER JOIN LOGIN LO on APU.fk_idlogin_aplicacionusuario = LO.pk_id_login where LO.usuario_login = '" + txtUsuario + "';";
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
        public OdbcDataReader consultadbper(string txtUsuario, string txtAplicacion)
        {
            try
            {
                Console.WriteLine(txtUsuario +" "+ txtAplicacion);
                string strConsulta = "insert into perfilusuario (fk_idusuario_perfilusuario, fk_idperfil_perfilusuario) values ((select pk_id_login from login where (usuario_login='"+ txtUsuario +"')),(select pk_id_perfil from perfil where (nombre_perfil='"+ txtAplicacion +"'))); ";
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
        public OdbcDataReader consultadb(string txtUsuario, string txtAplicacion)
        {
            try
            {
                string strConsulta = "insert into aplicacionusuario (fk_idlogin_aplicacionusuario, fk_idaplicacion_aplicacionusuario, fk_idpermiso_aplicacionusuario)  values((select pk_id_login from login where (usuario_login = '" + txtUsuario + "')), (select pk_id_aplicacion from aplicacion where(nombre_aplicacion= '" + txtAplicacion + "')),1); ";
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

