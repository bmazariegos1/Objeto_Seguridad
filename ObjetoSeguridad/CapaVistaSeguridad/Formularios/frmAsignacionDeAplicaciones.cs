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
        string valor, valor1;
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
            dgvAplicacionesAsignadas.Rows.Clear();
            dgvPerfilesAsignados.Rows.Clear();
            //funcion de llenado de lsvPerfilesDisponibles.Items perfiles pendiente
            //funcion de llenado de  lsvAplicacionesDisponibles.Items  aplicaciones pendiete
            // lsvAplicacionesasignadas.Items.Clear();
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
        public void mostrar_consulta_perfil_asignado()
        {
            OdbcDataReader mostrar = asignacionDeAplicaciones.consulta_perfiles_asignados(txtUsuario.Text);
            try
            {
                while (mostrar.Read())
                {
                    dgvPerfilesAsignados.Rows.Add(mostrar.GetString(0));
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
        public void mostrar_consulta_aplicacion_asignada()
        {
            OdbcDataReader mostrar = asignacionDeAplicaciones.consulta_aplicaciones_asignadas(txtUsuario.Text);
            try
            {
                while (mostrar.Read())
                {
                    dgvAplicacionesAsignadas.Rows.Add(mostrar.GetString(0));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        public void insertar_adb()
        {
            OdbcDataReader mostrar = asignacionDeAplicaciones.consulta_adb(txtUsuario.Text, valor);
            try
            {
    
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
        public void insertar_adbper()
        {
            OdbcDataReader mostrar = asignacionDeAplicaciones.consulta_adbper(txtUsuario.Text, valor1);
            try
            {
            
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

            mostrar_consulta_aplicacion_asignada();
            mostrar_consulta_perfil_asignado();
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

        private void btnAgregarTodo_Click(object sender, EventArgs e)
        {
            string ApliAsig, PerfiAsig;
            int a, b;
            bool x = false;
            a = 0;
            b = 0;

            ApliAsig = (dgvAplicacionesDisponibles.Rows[dgvAplicacionesDisponibles.CurrentRow.Index].Cells[0].Value.ToString());
            PerfiAsig = (dgvPerfilesDisponibles.Rows[dgvPerfilesDisponibles.CurrentRow.Index].Cells[0].Value.ToString());
            //lsvAplicacionesasignadas.Items.Add (dgvAplicacionesDisponibles.Rows[dgvAplicacionesDisponibles.CurrentRow.Index].Cells[0].Value.ToString()); 
            if (rbtnAplicaciones.Checked)
            {
                for (a = 0; a < dgvAplicacionesAsignadas.Rows.Count-1; a++)
                   
                {
                  
                    if (ApliAsig == dgvAplicacionesAsignadas.Rows[a].Cells[0].Value.ToString())
                    {
                        x = true;
                        a = dgvPerfilesAsignados.Rows.Count + 10;
                    }
                }
                if (x == false)
                {
                    dgvAplicacionesAsignadas.Rows.Add(ApliAsig);
                    //aca jala para db
                    valor = ApliAsig;
                    insertar_adb();
                }
            }
          

            if (rbtnPerfiles.Checked)
            {
                for ( b = 0; b < dgvPerfilesAsignados.Rows.Count-1 ; b++)
                     
                {
                    if (PerfiAsig == dgvPerfilesAsignados.Rows[b].Cells[0].Value.ToString())
                        {
                        x = true;
                        b = dgvPerfilesAsignados.Rows.Count + 10; 
                    }
                }
                if (x == false)
                {
                    dgvPerfilesAsignados.Rows.Add(PerfiAsig);
                    //aca jala db
                    valor1 = PerfiAsig;
                    insertar_adbper();
                }
            }
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
                if (rbtnPerfiles.Checked)
            {
              
                    int rowIndex = dgvPerfilesAsignados.CurrentCell.RowIndex;
                    dgvPerfilesAsignados.Rows.RemoveAt(rowIndex);
                
            }
            if (rbtnAplicaciones.Checked)
            {           
                    int rowIndex = dgvAplicacionesAsignadas.CurrentCell.RowIndex;
                    dgvAplicacionesAsignadas.Rows.RemoveAt(rowIndex);
            }
        }
    }
}

