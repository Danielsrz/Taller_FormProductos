using Domain;
using Data;
using Business;
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

        //MÉTODOS DEL FORMULARIO
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
            if (txtPrecio.Text == "") miProducto.Precio = 0.0;
            else miProducto.Precio = Convert.ToDouble(txtPrecio.Text);
            if (txtStock.Text == "") miProducto.Stock = 0;
            else miProducto.Stock = Convert.ToInt32(txtStock.Text);
            return miProducto;
        }

        private int ObtenerID() 
        {
            Producto miProducto = new Producto();
            miProducto.Id = IDProducto;
            return miProducto.Id;
        }

        private void ActualizarGrid()
        {
            IDProducto = 0;
            List<Producto> listaProductos = ProductoData.Buscar();
            dgvBuscar.DataSource = listaProductos;
        }


        //BOTONES Y ELEMENTOS DEL FORMULARIO
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto miProducto = ObtenerProducto();
            ProductoManager.Guardar(miProducto);
            ActualizarGrid();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = ObtenerID();
            ProductoManager.EliminarProducto(idEliminar);
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


    }
}
