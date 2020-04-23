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
        //VALIDAR SI HAY QUE AGREGAR O MODIFICAR UN PRODUCTO
        //VALIDAD SI TODOS LOS CAMPOS DEL FORMULARIO ESTAN COMPLETOS PARA AGREGAR UN PRODUCTO
        public static void Guardar(Producto miProducto)
        {
            bool formulario = ValidarFormulario(miProducto);
            if (miProducto.Id.Equals(0))
            {
                if (formulario == true)
                {
                    ProductoData.Agregar(miProducto);
                    MessageBox.Show("Producto agregado exitosamente", "Agregar producto");
                }
                else MessageBox.Show("Debe completar todos los campos", "Error");
                
            }
            else
            {
                ProductoData.Actualizar(miProducto);
            }
        }

        //VALIDAD QUE ESTE SELECCIONADO UN ELEMENTO PARA PODER ELIMINARLO
        public static void EliminarProducto(int pId)
        {
            if (pId.Equals(0))
            {
                MessageBox.Show("Por favor seleccione un Producto");
            }
            else
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ProductoData.Eliminar(pId);
                }
            }
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
