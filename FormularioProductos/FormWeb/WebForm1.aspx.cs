using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using Data;
using Business;

namespace FormWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public int IDProducto;

        private void ActualizarControles()
        {
            //btnGuardar.Text = "Guardar";
            //IDProducto =
            //txtNombre.Text =
            //txtDescripcion.Text =
            //txtPrecio.Text =
            //txtStock.Text =
        }

        private void LimpiarCampos()
        {
            btnGuardar.Text = "Agregar";
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

        protected void Page_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}