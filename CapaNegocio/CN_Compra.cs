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
    public class CN_Compra
    {
        private CD_Compra objetoCD = new CD_Compra();

        public DataTable MostrarCompra()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCompras();
            return tabla;
        }
        public void InsertarCompras(int cod, string nombre, double precio, string descrip, int cant, string fecha, int idInventario)
        {

            objetoCD.InsertarCompra(cod,nombre, precio, descrip, cant, fecha, idInventario);
        }

        public void ActualizarCompra(int cod, string nombre, double precio, string descrip, int cant, string fecha, int idInventario, int id)
        {
            objetoCD.ActualizarCompras(cod, nombre, precio, descrip, cant, fecha, idInventario,id);
        }

        public void EliminarCompr(string id)
        {

            objetoCD.EliminarCompra(Convert.ToInt32(id));
        }

    }
}
