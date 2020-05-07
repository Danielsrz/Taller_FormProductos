using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Data;


namespace Business
{
    public class PedidoManager
    {
        public static List<Pedido> ObtenerPedido()
        {
            return PedidoData.BuscarPedido();
        }

        public static void GuardarPedido(Pedido miPedido)
        {
            PedidoData.AgregarPedido(miPedido);
        }
    }
}
