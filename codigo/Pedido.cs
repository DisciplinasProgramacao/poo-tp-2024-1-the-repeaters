using POO___Abner;
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
            double total = CalcularTotal();
            Console.WriteLine($"Total: R$ {total:F2}");
            Console.WriteLine($"Valor por Pessoa: R$ {(total / numeroPessoas):F2}");
        }

        /// <summary>
        /// Calcula o valor total do pedido incluindo a taxa de serviço.
        /// </summary>
        /// <returns>O valor total do pedido.</returns>
        private double CalcularTotal()
        {
            double total = 0;
            foreach (var item in itens)
            {
                total += item.Valor;
            }
            total += total * taxaServico;
            return total;
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
