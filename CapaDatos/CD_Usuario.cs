using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlTypes;
using Common;


namespace CapaDatos
{
  
    public class CD_Usuario : ConnectionToSql  // Heredamos de la clase ConnectionToSql
    {
        private CD_Conexion conexion = new CD_Conexion(); // Connection object
        SqlCommand comando = new SqlCommand(); // SqlCommand object

        //  insertar usuario
        public void Insertar_New_Usuario(string nombre, string apellido, int edad, string correo, string direccion, string urlImagen, string contrasena
            , string sexo, string cargo, string estadoCivil, string cedula, string telefono)
        {
            comando.Connection = conexion.AbrirConexion();                 // Open connection
            comando.CommandText = "AgregarUsuario";                       // Stored procedure
            comando.CommandType = CommandType.StoredProcedure;           // Command type
            comando.Parameters.AddWithValue("@Nombre", nombre);         // Parameters
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@edad", edad);
            comando.Parameters.AddWithValue("@correo", correo);
            comando.Parameters.AddWithValue("@direccion", direccion);
            comando.Parameters.AddWithValue("@urlimagen", urlImagen);
            comando.Parameters.AddWithValue("@contrasena", contrasena);
            comando.Parameters.AddWithValue("@sexo", sexo);
            comando.Parameters.AddWithValue("@cargo", cargo);
            comando.Parameters.AddWithValue("@estado_civil", estadoCivil);
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@telefono", telefono);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }



        // obtener usuario de la clase UserLoginCache de la capa Common 
        public object  UserLCache{ get; private set; }




        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from usuario where nombre=@user and contrasena=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            UserCache.id = reader.GetInt32(0);
                            UserCache.nombre = reader.GetString(1);
                            UserCache.apellido = reader.GetString(2);
                            UserCache.edad = reader.GetInt32(3);
                            UserCache.correo = reader.GetString(4);
                            UserCache.direccion = reader.GetString(5);
                            UserCache.urlimagen = reader.GetString(6);
                            UserCache.contrasena = reader.GetString(7);
                            UserCache.sexo = reader.GetString(8);
                            UserCache.cargo = reader.GetString(9);
                            UserCache.estado_civil = reader.GetString(10);
                            UserCache.cedula = reader.GetString(11);
                            UserCache.telefono = reader.GetString(12);



                            return true;
                        }
                    }
                    else
                        return false;
                }
            }
            return true;
        }


        //public bool Login(string user, string pass)
        //{
        //    using (var connection = conexion.AbrirConexion())
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandText = "select *from Usuario where nombre=@user and contrasena=@pass";
        //            command.Parameters.AddWithValue("@user", user);
        //            command.Parameters.AddWithValue("@pass", pass);
        //            command.CommandType = CommandType.Text;
        //            SqlDataReader reader = command.ExecuteReader();
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {

        //                    UserCache.id = reader.GetInt32(0);
        //                    UserCache.nombre = reader.GetString(1);
        //                    UserCache.apellido = reader.GetString(2);
        //                    UserCache.edad = reader.GetInt32(3);
        //                    UserCache.correo = reader.GetString(4);
        //                    UserCache.direccion = reader.GetString(5);
        //                    UserCache.urlimagen = reader.GetString(6);
        //                    UserCache.contrasena = reader.GetString(7);
        //                    UserCache.sexo = reader.GetString(8);
        //                    UserCache.cargo = reader.GetString(9);
        //                    UserCache.estado_civil = reader.GetString(10);
        //                    UserCache.cedula = reader.GetString(111);
        //                    UserCache.telefono = reader.GetString(12);


        //                    return true;
        //                }
        //            }
        //            else
        //                return false;
        //        }
        //    }
        //    return true;
        //}


    }
}
