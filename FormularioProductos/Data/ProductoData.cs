using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductoData
    {

        public static void Guardar(Producto miProducto)
        {
            if (miProducto.Id == 0) Agregar(miProducto);
            else Actualizar(miProducto);
        }

        public static List<Producto> Buscar()
        {
            List<Producto> listaProductos = new List<Producto>();

            SqlCommand comando = new SqlCommand("GetProductos", BaseDatos.ObtenerConexion());
            comando.CommandType = System.Data.CommandType.StoredProcedure;
           
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Producto miProducto = new Producto();
                miProducto.Id = reader.GetInt32(0);
                miProducto.Nombre = reader.GetString(1);
                miProducto.Descripcion = reader.GetString(2);
                miProducto.Precio = reader.GetDouble(3);
                miProducto.Stock = reader.GetInt32(4);

                listaProductos.Add(miProducto);
            }
            return listaProductos;
        }

        public static void Actualizar(Producto miProducto)
        {
            SqlConnection conexion = BaseDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand(string.Format("Update productos set Nombre='{0}', Descripción='{1}', Precio='{2}', Stock='{3}' where IdProducto={4}",
                miProducto.Nombre, miProducto.Descripcion, miProducto.Precio, miProducto.Stock, miProducto.Id), conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static void Agregar(Producto miProducto)
        {
            SqlCommand comando = new SqlCommand(string.Format("Insert into productos (Nombre, Descripción, Precio, Stock) values ('{0}','{1}','{2}', '{3}')",
                miProducto.Nombre, miProducto.Descripcion, miProducto.Precio, miProducto.Stock), BaseDatos.ObtenerConexion());
            comando.ExecuteNonQuery();
        }

        public static void Eliminar(int pId)
        {
            SqlConnection conexion = BaseDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand(string.Format("Delete From productos where IDProducto={0}", pId), conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
