using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Data;

namespace Business
{
    public class ProductoManager
    {
        public static List<Producto> Obtener()
        {
            return ProductoData.Buscar();
        }

        public static void Guardar(Producto miProducto)
        {
            ProductoData.Agregar(miProducto);
        }

        public static void Actualizar(Producto miProducto)
        {
            ProductoData.Actualizar(miProducto);
        }

        public static void EliminarProducto(int pId)
        {
            ProductoData.Eliminar(pId);
        }

        public static List<Cliente> ObtenerCliente()
        {
            return ProductoData.BuscarCliente();
        }


        //METODO PARA VALIDAR QUE TODOS LOS CAMPOS DEL FORMULARIO ESTEN COMPLETOS
        public static bool ValidarFormulario(Producto miProducto)
        {
            bool formularioVacio = true;

            if (miProducto.Nombre == "" || miProducto.Descripcion == "" || miProducto.Precio == 0 || miProducto.Stock == 0)
            {
                formularioVacio = false;
            }

            return formularioVacio;
        }
    }
}
