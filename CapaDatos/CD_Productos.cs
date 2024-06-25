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
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        private DateTime fech;

        public DataTable Mostrar()
        {
           
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "MostrarProductosCreados";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }

        public void Insertar(string nombre, double cant, int cod, string fecha, int idInventario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertarProductosCreados";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Cantidad", cant);
            comando.Parameters.AddWithValue("@Codigo", cod);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@InventarioId", idInventario);
            

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Editar(string nombre, int cant, int cod, string fecha, int idInventario, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ActualizarProductosCreados";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Cantidad", cant);
            comando.Parameters.AddWithValue("@Codigo", cod);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@InventarioId", idInventario);
            comando.Parameters.AddWithValue("@Id", id);




            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProductosCreadosPorId";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
