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
        public static List<Producto> Buscar()
        {
            List<Producto> listaProductos = new List<Producto>();

            SqlConnection conexion = BaseDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand("GetProductos", conexion);
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
            conexion.Close();
            return listaProductos;
        }

        public static void Agregar(Producto miProducto)
        {
            SqlConnection conexion = BaseDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand("InsertProductos", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", miProducto.Nombre);
            comando.Parameters.AddWithValue("@Descripción", miProducto.Descripcion);
            comando.Parameters.AddWithValue("@Precio", miProducto.Precio);
            comando.Parameters.AddWithValue("@Stock", miProducto.Stock);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static void Actualizar(Producto miProducto)
        {
            SqlConnection conexion = BaseDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand("UpdateProductos", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", miProducto.Nombre);
            comando.Parameters.AddWithValue("@Descripción", miProducto.Descripcion);
            comando.Parameters.AddWithValue("@Precio", miProducto.Precio);
            comando.Parameters.AddWithValue("@Stock", miProducto.Stock);
            comando.Parameters.AddWithValue("@ID", miProducto.Id);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static void Eliminar(int pId)
        {
            SqlConnection conexion = BaseDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand("DeleteProductos", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID", pId);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static List<Cliente> BuscarCliente()
        {
            List<Cliente> _lista = new List<Cliente>();

            SqlCommand _comando = new SqlCommand("GetClientes", BaseDatos.ObtenerConexion());
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Cliente pCliente = new Cliente();
                pCliente.Id = _reader.GetInt32(0);
                pCliente.Nombre = _reader.GetString(1);
                pCliente.Apellido = _reader.GetString(2);
                pCliente.Fecha_Nac = _reader.GetString(3);
                pCliente.Direccion = _reader.GetString(4);


                _lista.Add(pCliente);
            }

            return _lista;
        }
    }
}
