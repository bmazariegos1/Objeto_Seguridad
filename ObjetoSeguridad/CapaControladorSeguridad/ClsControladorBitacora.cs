using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModeloSeguridad;

namespace CapaControladorSeguridad
{
    public class ClsControladorBitacora
    {

        ClsModeloBitacora b = new ClsModeloBitacora();

        public void usuario(int usuario) //obtiene el usuario
        {
            b.UserSystem = usuario;
            //usuario = b.UserSystem;
        }

        public void acciones(int aplicacion, String accion) //obtiene los valores necesarios para registrar movimientos
        {
            b.nombreAplicacion = aplicacion;
            b.accion = accion;

            b.Insertar();
        }

    }
}
