using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Trabalho
{
    /// <summary>
    /// Representa uma reserva de mesa em um restaurante.
    /// </summary>
    public class Reserva
    {
        private int idReserva;
        private int quantPessoa;
        private DateTime dataEntrada;
        private DateTime? dataSaida;
        private Mesa mesaAlocada;
        private Cliente cliente;
        private Pedido pedido;

        public Pedido Pedido { get { return pedido; } }
        public DateTime DataEntrada { get { return dataEntrada; } }
        public DateTime? DataSaida { get { return dataSaida; } }
        public int QuantPessoa { get { return quantPessoa; } }
        public int IdReserva { get { return idReserva; } }
        public Cliente Cliente { get { return cliente; } }
        public Mesa MesaAlocada { get { return mesaAlocada; } set { mesaAlocada = value; } }

        /// <summary>
        /// Inicializa uma nova instância da classe Reserva.
        /// </summary>
        /// <param name="cliente">O cliente associado à reserva.</param>
        /// <param name="idReserva">O ID da reserva.</param>
        /// <param name="quantPessoa">A quantidade de pessoas na reserva.</param>
        /// <param name="dataEntrada">A data de entrada da reserva.</param>
        /// <param name="mesaAlocada">A mesa alocada para a reserva.</param>
        /// <exception cref="InvalidOperationException">Lançada se a mesa já está ocupada ou a capacidade é excedida.</exception>
        public Reserva(Cliente cliente, int idReserva, int quantPessoa, DateTime dataEntrada, Mesa mesaAlocada)
        {
            this.cliente = cliente;
            this.idReserva = idReserva;
            this.quantPessoa = quantPessoa;
            this.dataEntrada = dataEntrada;
            this.mesaAlocada = mesaAlocada;
            this.pedido = new Pedido();

            if (mesaAlocada != null)
            {
                if (!mesaAlocada.OcuparMesa(quantPessoa))
                {
                    throw new InvalidOperationException("A mesa já está ocupada ou a capacidade é excedida.");
                }
            }
        }

        /// <summary>
        /// Adiciona um produto ao pedido da reserva.
        /// </summary>
        /// <param name="produto">O produto a ser adicionado.</param>
        public void ReceberPedido(Produto produto)
        {
            if (pedido.PedidoAberto)
            {
                pedido.addItem(produto);
                Console.WriteLine($"Produto '{produto.Nome}' adicionado ao pedido.");
            }
            else
            {
                Console.WriteLine("A reserva ainda está aberta. Feche o pedido antes de calcular a conta.");
            }
        }

        /// <summary>
        /// Inclui produtos ao pedido da reserva com base nos IDs dos produtos.
        /// </summary>
        /// <param name="idsProdutos">Lista de IDs dos produtos.</param>
        /// <param name="cardapio">O cardápio para consultar os produtos.</param>
        public void IncluirPedido(List<int> idsProdutos, Cardapio cardapio)
        {
            if (this.pedido == null)
            {
                this.pedido = new Pedido();
            }

            if (this.pedido.Itens == null)
            {
                this.pedido.Itens = new List<Produto>();
            }

            cardapio.GerarPedido(idsProdutos, this.pedido.Itens);
        }

        /// <summary>
        /// Exibe o valor total por cliente na reserva.
        /// </summary>
        public void ExibirValorPorCliente()
        {
            if (!pedido.PedidoAberto)
            {
                int numeroPessoas = quantPessoa;
                pedido.FecharPedido(numeroPessoas);
            }
            else
            {
                Console.WriteLine("A reserva ainda está aberta. Feche o pedido antes de exibir o valor por cliente.");
            }
        }

        /// <summary>
        /// Finaliza a reserva e libera a mesa associada.
        /// </summary>
        /// <param name="horaSaida">A data e hora de saída.</param>
        /// <exception cref="InvalidOperationException">Lançada se a reserva já foi finalizada.</exception>
        public void FinalizarReserva(DateTime horaSaida)
        {
            if (dataSaida.HasValue)
            {
                throw new InvalidOperationException("Esta reserva já foi finalizada.");
            }

            dataSaida = horaSaida;

            if (mesaAlocada != null)
            {
                mesaAlocada.LiberarMesa();
            }
        }
    }
}
