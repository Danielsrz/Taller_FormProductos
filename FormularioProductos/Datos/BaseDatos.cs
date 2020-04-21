using System;
using System.Data.SqlClient;

namespace Datos
{
    public class BaseDatos
    {

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conectar = new SqlConnection("Data Source=DESKTOP-QN49N6K;Initial Catalog=Taller;Integrated Security=true;");

            conectar.Open();
            return conectar;
        }

    }
}
