using CapaControladorSeguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVistaSeguridad.Formularios
{
    public partial class frmAsignacionDeAplicaciones : Form
    {
        clsControlAsignacionDeAplicaciones asignacionDeAplicaciones = new clsControlAsignacionDeAplicaciones();
        public frmAsignacionDeAplicaciones()
        {
            InitializeComponent();
            inicio();
        }
        public void inicio()
        {
            txtUsuario.Text = "";
            txtNombreUsuario.Text = "";
            gbxUsuarioSelect.Enabled = true;
            gbxPerfilesyAplicaciones.Enabled = false;
            rbtnPerfiles.Checked = true;
            rbtnAplicaciones.Checked = false;
            dgvAplicacionesDisponibles.Enabled = true;
            dgvPerfilesDisponibles.Enabled = false;
            //funcion de llenado de lsvPerfilesDisponibles.Items perfiles pendiente
            //funcion de llenado de  lsvAplicacionesDisponibles.Items  aplicaciones pendiete
            lsvAplicacionesasignadas.Items.Clear();
        }

        public void ControlRadioBoton()
        {
            if (rbtnPerfiles.Checked == true)
            {
                dgvAplicacionesDisponibles.Enabled = false;
                dgvPerfilesDisponibles.Enabled = true;
            }
            else
            {
                dgvPerfilesDisponibles.Enabled = false;
                dgvAplicacionesDisponibles.Enabled = true;
            }
        }
        public void mostrar_consulta_perfil()
        {
            OdbcDataReader mostrar = asignacionDeAplicaciones.consulta_perfiles();
            try
            {
                while (mostrar.Read())
                {
                    dgvPerfilesDisponibles.Rows.Add(mostrar.GetString(0));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void mostrar_consulta_aplicacion()
        {
            OdbcDataReader mostrar = asignacionDeAplicaciones.consulta_aplicaciones();
            try
            {
                while (mostrar.Read())
                {
                    dgvAplicacionesDisponibles.Rows.Add(mostrar.GetString(0));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            inicio();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String NombreUsuario = asignacionDeAplicaciones.NombreUsuario(txtUsuario.Text);
            if (String.IsNullOrEmpty(NombreUsuario))
            {
                MessageBox.Show("Usuario " + txtUsuario.Text + " Invalido");
                txtUsuario.Text = "";
            }
            else
            {
                gbxUsuarioSelect.Enabled = false;
                gbxPerfilesyAplicaciones.Enabled = true;
                txtNombreUsuario.Text = NombreUsuario;
            }
        }

        private void rbtnPerfiles_CheckedChanged(object sender, EventArgs e)
        {
            ControlRadioBoton();
        }

        private void rbtnAplicaciones_CheckedChanged(object sender, EventArgs e)
        {
            ControlRadioBoton();
        }

        private void frmAsignacionDeAplicaciones_Load(object sender, EventArgs e)
        {
            mostrar_consulta_perfil();
            mostrar_consulta_aplicacion();
        }
    }
}
