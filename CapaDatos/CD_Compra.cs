using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlTypes;
namespace CapaNegocio
{
    public class CD_Compra
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        private DateTime fech;

        public DataTable MostrarCompras()
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarCompra";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void InsertarCompra(int cod, string nombre, double precio, string descrip, int cant,string fecha, int idInventario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarCompra";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Codigo", cod);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Descripcion", descrip);
            comando.Parameters.AddWithValue("@Cantidad", cant);
            comando.Parameters.AddWithValue("@Fecha", fecha);
            comando.Parameters.AddWithValue("@InventarioId", idInventario);



            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void ActualizarCompras(int cod, string nombre, double precio, string descrip, int cant, string fecha, int inventario, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarCompra";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Codigo", cod);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Descripcion", descrip);
            comando.Parameters.AddWithValue("@Cantidad", cant);
            comando.Parameters.AddWithValue("@Fecha", fecha);
            comando.Parameters.AddWithValue("@InventarioId", inventario);
            comando.Parameters.AddWithValue("@Id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EliminarCompra(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarCompraPorId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
