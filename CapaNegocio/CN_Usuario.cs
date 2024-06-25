using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objetoCD = new CD_Usuario();

        public void InsertarUsuario(string nombre, string apellido, int edad, string correo, string direccion, string urlImagen, string contrasena
            , string sexo, string cargo, string estadoCivil, string cedula, string telefono)
        {
            objetoCD.Insertar_New_Usuario(nombre, apellido, edad, correo, direccion, urlImagen, contrasena
            , sexo, cargo, estadoCivil, cedula, telefono);
        }


    }
}
