using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Representa um pedido contendo produtos e métodos para calcular valores do pedido.
    /// </summary>
    public class Pedido
    {
        private List<Produto> itens = new List<Produto>();
        private static double taxaServico = 0.10;
        public bool pedidoAberto = true;

        /// <summary>
        /// Calcula o valor total dos itens do pedido.
        /// </summary>
        /// <returns>O valor total dos itens.</returns>
        public double CalcularPedido()
        {
            double total = 0;
            foreach (var item in itens)
            {
                total += item.Valor;
            }
            return total;
        }
        public int addItem(Produto produto)
        {
            if (produto != null)
            {
                itens.Add(produto);
            }
            return itens.Count;
        }

        public void FecharPedido(int numeroPessoas)
        {
            pedidoAberto = false;
        }

        /// <summary>
        /// Calcula o valor da taxa de serviço do pedido.
        /// </summary>
        /// <returns>O valor da taxa de serviço.</returns>
        public double CalcularTaxa()
        {
            return CalcularPedido() * taxaServico;
        }

        /// <summary>
        /// Calcula o valor total do pedido, incluindo a taxa de serviço.
        /// </summary>
        /// <returns>O valor total do pedido.</returns>
        public double CalcularTotal()
        {
            return CalcularPedido() + CalcularTaxa();
        }

        /// <summary>
        /// Obtém ou define a lista de produtos do pedido.
        /// </summary>
        public List<Produto> Itens
        {
            get { return itens; }
            set { itens = value; }
        }

        public bool PedidoAberto { get; internal set; }
    }
}