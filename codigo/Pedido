using POO3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO3
{
    public class Pedido
    {
        private List<Produto> itens = new List<Produto>();
        private static double taxaServico = 0.10;
        private int quantidadeItens;
        private bool pedidoAberto;


        public int addItem(Produto produto)
        {
            if (produto != null)
            {
                itens.Add(produto);
            }
            return quantidadeItens++;
        }

        public void FecharPedido(int numeroPessoas)
        {
            pedidoAberto = false;
            double a = CalcularTotal();
            Console.WriteLine($"Total: R$ {a:F2}");
            Console.WriteLine($"Valor por Pessoa: R$ {(a/numeroPessoas):F2}");  
        }

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

        public void Relatorio(int idReservaPed)
        {
            Console.WriteLine($"Relatório do Pedido da Reserva ID: {idReservaPed}");
            foreach (var item in itens)
            {
                Console.WriteLine($"- {item.Nome}: R$ {item.Valor:F2}");
            }
        }


        public bool PedidoAberto { get { return pedidoAberto; } }

        public List<Produto> Itens { get { return itens; } }
    }
}
