using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using Business;

namespace WebApiProductos.Controllers
{
    public class PedidoController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Pedido> Get()
        {
            return PedidoManager.ObtenerPedido();
        }

        // POST api/<controller>
        public void Post([FromBody]Pedido miPedido)
        {
            PedidoManager.GuardarPedido(miPedido);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}