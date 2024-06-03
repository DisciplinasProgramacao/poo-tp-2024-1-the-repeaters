using System;
using System.Collections.Generic;

namespace ConsoleApp5
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

        // Propriedades públicas para acesso aos dados da reserva
        public Pedido Pedido { get { return pedido; } }
        public DateTime DataEntrada { get { return dataEntrada; } }
        public DateTime? DataSaida { get { return dataSaida; } }
        public int QuantPessoa { get { return quantPessoa; } }
        public int IdReserva { get { return idReserva; } }
        public Cliente Cliente { get { return cliente; } }
        public Mesa MesaAlocada { get { return mesaAlocada; } set { mesaAlocada = value; } }

        // <summary>
        /// Cria uma nova instância de Reserva.
        /// </summary>
        /// <param name="cliente">O cliente associado à reserva.</param>
        /// <param name="idReserva">O identificador único da reserva.</param>
        /// <param name="quantPessoa">A quantidade de pessoas na reserva.</param>
        /// <param name="dataEntrada">A data e hora de entrada da reserva.</param>
        /// <param name="mesaAlocada">A mesa alocada para a reserva (pode ser nulo se não houver mesa disponível).</param>
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
                pedido.AdicionarItem(produto);
                Console.WriteLine($"Produto '{produto.Nome}' adicionado ao pedido da reserva ID: {idReserva}.");
            }
            else
            {
                Console.WriteLine("A reserva está fechada. Não é possível adicionar itens ao pedido.");
            }
        }

        /// <summary>
        /// Calcula o valor total da conta com base nos itens do pedido.
        /// </summary>
        public void FecharConta()
        {
            if (!pedido.PedidoAberto)
            {
                decimal totalConta = pedido.CalcularTotal();
                Console.WriteLine($"Total da conta para {cliente.Nome}: R$ {totalConta:F2}");
            }
            else
            {
                Console.WriteLine("A reserva ainda está aberta. Feche o pedido antes de calcular a conta.");
            }
        }

        /// <summary>
        /// Calcula e exibe o valor por pessoa para o cliente.
        /// </summary>
        public void ExibirValorPorCliente()
        {
            if (!pedido.PedidoAberto)
            {
                int numeroPessoas = quantPessoa;
                decimal valorPorPessoa = pedido.CalcularTotal() / numeroPessoas;
                Console.WriteLine($"Valor por pessoa para {cliente.Nome}: R$ {valorPorPessoa:F2}");
            }
            else
            {
                Console.WriteLine("A reserva ainda está aberta. Feche o pedido antes de exibir o valor por cliente.");
            }
        }

        /// <summary>
        /// Marca a reserva como finalizada, definindo a hora de saída.
        /// Libera a mesa alocada (se houver).
        /// </summary>
        /// <param name="horaSaida">A hora de saída da reserva.</param>
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
