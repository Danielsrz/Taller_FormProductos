using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Data
{
    public class PedidoData
    {
        public static List<Pedido> BuscarPedido()
        {
            List<Pedido> listaPedido = new List<Pedido>();

            SqlConnection conexion = BaseDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand("GetPedidos", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Pedido miPedido = new Pedido();
                //miPedido.ID = reader.GetInt32(0);
                miPedido.IDCliente = reader.GetString(0);
                miPedido.IDProducto = reader.GetString(1);
                miPedido.Cantidad = reader.GetInt32(2);
                listaPedido.Add(miPedido);
                Producto miProducto = new Producto();

            }
            conexion.Close();
            return listaPedido;
        }

        public static void AgregarPedido(Pedido miPedido)
        {
            SqlConnection conexion = BaseDatos.ObtenerConexion();
            SqlCommand comando = new SqlCommand("InsertPedido", conexion);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IDCliente", miPedido.IDCliente);
            comando.Parameters.AddWithValue("@IDProducto", miPedido.IDProducto);
            comando.Parameters.AddWithValue("@Cantidad", miPedido.Cantidad);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
