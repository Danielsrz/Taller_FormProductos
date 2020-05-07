using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business;
using Domain;

namespace WebApiProductos.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Producto> Get()
        {
            return ProductoManager.Obtener();
        }

        // POST api/<controller>
        public void Post([FromBody]Producto producto)
        {
            ProductoManager.Guardar(producto);
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Producto producto)
        {
            ProductoManager.Actualizar(producto);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            ProductoManager.EliminarProducto(id);
        }
    }
}