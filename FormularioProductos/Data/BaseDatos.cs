using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BaseDatos
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conectar = new SqlConnection("Data Source=DESKTOP-QN49N6K\\DANIELDB;Initial Catalog=Taller;Integrated Security=true;");

            conectar.Open();
            return conectar;
        }

    }
}
