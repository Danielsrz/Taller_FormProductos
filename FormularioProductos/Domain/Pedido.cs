using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pedido
    {
        public int ID { get; set; }
        public string IDCliente { get; set; }
        public string IDProducto { get; set; }
        public int Cantidad { get; set; }
       

        public Pedido() { }

        public Pedido(int Id, string pCliente, string pProducto, int pCantidad)
        {
            this.ID = Id;
            this.IDCliente = pCliente;
            this.IDProducto = pProducto;
            this.Cantidad = pCantidad;
        }
    }
}
