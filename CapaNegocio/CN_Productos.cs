using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public DataTable MostrarProd()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarPRod(string nombre, string cant, string cod, string fecha, string id)
        {

            objetoCD.Insertar( nombre, Convert.ToInt32(cant), Convert.ToInt32(cod), fecha, Convert.ToInt32(id));
        }

        public void EditarProd(string nombre, string cant, string cod, string fecha,string idInvetario, string id)
        {
            objetoCD.Editar(nombre, Convert.ToInt32(cant), Convert.ToInt32(cod), fecha,Convert.ToInt32(idInvetario),Convert.ToInt32(id));
        }

        public void EliminarPRod(string id)
        {

            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
