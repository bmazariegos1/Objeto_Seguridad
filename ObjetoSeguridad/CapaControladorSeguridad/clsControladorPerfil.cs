using CapaModeloSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladorSeguridad
{
    public class clsControladorPerfil
    {
        clsModeloPerfil Modelo = new clsModeloPerfil();

        public bool Login(string strUsuario, string strContraseña)
        {
            return Modelo.Login(strUsuario, strContraseña);
        }

    }
}
