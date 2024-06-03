using System;
using System.Collections.Generic;

namespace POO___Abner
{
    public class Pedido
    {
        private List<Produto> itens = new List<Produto>();
        private static double taxaServico = 0.10;
        private bool pedidoAberto;

        /// <summary>
        /// Adiciona um item ao pedido.
        /// </summary>
        /// <param name="produto">Produto a ser adicionado ao pedido.</param>
        /// <returns>O número de itens no pedido após a adição.</returns>
        public int addItem(Produto produto)
        {
            if (produto != null)
            {
                itens.Add(produto);
            }
            return itens.Count;
        }

        /// <summary>
        /// Fecha o pedido e exibe o total a ser pago e o valor por pessoa.
        /// </summary>
        /// <param name="numeroPessoas">Número de pessoas para dividir o valor total.</param>
        public void FecharPedido(int numeroPessoas)
        {
            pedidoAberto = false;
            Console.WriteLine("Valor do Pedido: R$ " + CalcularPedido().ToString("F2"));
            Console.WriteLine("Valor da Taxa do Serviço: R$ " + CalcularTaxa());
            Console.WriteLine("Valor do Total: R$ " + CalcularTotal());
            Console.WriteLine($"Valor por Pessoa: R$ {(CalcularTotal() / numeroPessoas):F2}");
        }

        /// <summary>
        /// Calcula o valor total dos itens no pedido.
        /// </summary>
        /// <returns>O valor total dos itens no pedido.</returns>
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
        /// Calcula a taxa de serviço do pedido.
        /// </summary>
        /// <returns>O valor da taxa de serviço.</returns>
        public double CalcularTaxa()
        {
            return CalcularPedido() * taxaServico;
        }

        /// <summary>
        /// Calcula o valor total do pedido incluindo a taxa de serviço.
        /// </summary>
        /// <returns>O valor total do pedido.</returns>
        private double CalcularTotal()
        {
            return CalcularPedido() + CalcularTaxa();
        }

        /// <summary>
        /// Gera um relatório do pedido.
        /// </summary>
        /// <param name="idReservaPed">ID da reserva associada ao pedido.</param>
        public void Relatorio(int idReservaPed)
        {
            Console.WriteLine($"Relatório do Pedido da Reserva ID: {idReservaPed}");
            foreach (var item in itens)
            {
                Console.WriteLine($"- {item.Nome}: R$ {item.Valor:F2}");
            }
        }

        /// <summary>
        /// Indica se o pedido está aberto.
        /// </summary>
        public bool PedidoAberto { get { return pedidoAberto; } }

        /// <summary>
        /// Obtém os itens do pedido.
        /// </summary>
        public List<Produto> Itens { get { return itens; } }
    }
}
