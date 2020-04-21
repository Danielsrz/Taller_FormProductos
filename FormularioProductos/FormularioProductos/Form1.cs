using Domain;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormularioProductos
{
    public partial class formProductos : Form
    {
        public formProductos()
        {
            InitializeComponent();
        }

        public int IDProducto;

        private void ActualizarControles()
        {
            btnGuardar.Text = "Guardar";
            IDProducto = Convert.ToInt32(dgvBuscar.CurrentRow.Cells[0].Value);
            txtNombre.Text = Convert.ToString(dgvBuscar.CurrentRow.Cells[1].Value);
            txtDescripcion.Text = Convert.ToString(dgvBuscar.CurrentRow.Cells[2].Value);
            txtPrecio.Text = Convert.ToString(dgvBuscar.CurrentRow.Cells[3].Value);
            txtStock.Text = Convert.ToString(dgvBuscar.CurrentRow.Cells[4].Value);
        }

        private void LimpiarCampos()
        {
            btnGuardar.Text = "Nuevo";
            IDProducto = 0;
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private Producto ObtenerProducto()
        {
            Producto miProducto = new Producto();

            miProducto.Id = IDProducto;
            miProducto.Nombre = txtNombre.Text;
            miProducto.Descripcion = txtDescripcion.Text;
            miProducto.Precio = Convert.ToDouble(txtPrecio.Text);
            miProducto.Stock = Convert.ToInt32(txtStock.Text);

            return miProducto;
        }

        private void ActualizarGrid()
        {
            IDProducto = 0;
            List<Producto> listaProductos = ProductoData.Buscar();
            dgvBuscar.DataSource = listaProductos;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto miProducto = ObtenerProducto();
            ProductoData.Guardar(miProducto);
            ActualizarGrid();
            LimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvBuscar_Click(object sender, EventArgs e)
        {
            ActualizarControles();
        }

        private void formProductos_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IDProducto.Equals(0))
            {
                MessageBox.Show("Por favor seleccione un Producto");
            }
            else
            {
                if (MessageBox.Show("¿Está seguro que desea eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Producto miProducto = ObtenerProducto();
                    ProductoData.Eliminar(miProducto.Id);
                    ActualizarGrid();
                    LimpiarCampos();
                }
            }
        }
    }
}
