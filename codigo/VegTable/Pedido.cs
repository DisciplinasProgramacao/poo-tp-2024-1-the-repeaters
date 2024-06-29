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

        /// <summary>
        /// Adiciona um item ao pedido.
        /// </summary>
        /// <param name="produto">O produto a ser adicionado ao pedido.</param>
        /// <returns>O número total de itens no pedido após a adição.</returns>
        public int addItem(Produto produto)
        {
            if (produto != null)
            {
                itens.Add(produto);
            }
            return itens.Count;
        }

        /// <summary>
        /// Fecha o pedido, marcando-o como concluído.
        /// </summary>
        /// <param name="numeroPessoas">O número de pessoas para o qual o pedido está sendo fechado.</param>
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

        /// <summary>
        /// Obtém ou define se o pedido está aberto.
        /// </summary>
        public bool PedidoAberto { get; internal set; }
    }
}