using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Inventario
    {
      
        private CD_Inventario objetoCD = new CD_Inventario();
        public DataTable MostrarInventario()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarInventario();
            return tabla;
        }

    }
}
