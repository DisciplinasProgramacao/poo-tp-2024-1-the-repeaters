using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Classe Reserva representa uma reserva em um restaurante, associada a uma mesa e um cliente.
    /// </summary>
    public class Reserva
    {
        // Atributos privados
        private int idReserva;
        private int quantPessoa;
        private DateTime dataEntrada;
        private DateTime? dataSaida;
        private Mesa mesaAlocada;
        private Cliente cliente;
        private Pedido pedido;

        // Propriedades públicas para acessar os atributos privados
        /// <summary>
        /// Obtém o pedido associado à reserva.
        /// </summary>
        public Pedido Pedido { get { return pedido; } }

        /// <summary>
        /// Obtém a data e hora de entrada da reserva.
        /// </summary>
        public DateTime DataEntrada { get { return dataEntrada; } }

        /// <summary>
        /// Obtém ou define a data e hora de saída da reserva.
        /// </summary>
        public DateTime? DataSaida { get { return dataSaida; } }

        /// <summary>
        /// Obtém a quantidade de pessoas associadas à reserva.
        /// </summary>
        public int QuantPessoa { get { return quantPessoa; } }

        /// <summary>
        /// Obtém o identificador único da reserva.
        /// </summary>
        public int IdReserva { get { return idReserva; } }

        /// <summary>
        /// Obtém o cliente associado à reserva.
        /// </summary>
        public Cliente Cliente { get { return cliente; } }

        /// <summary>
        /// Obtém ou define a mesa alocada para a reserva.
        /// </summary>
        public Mesa MesaAlocada { get { return mesaAlocada; } set { mesaAlocada = value; } }

        /// <summary>
        /// Construtor da classe Reserva. Inicializa uma nova instância da classe com os parâmetros especificados.
        /// </summary>
        /// <param name="cliente">O cliente associado à reserva.</param>
        /// <param name="idReserva">O identificador único da reserva.</param>
        /// <param name="quantPessoa">A quantidade de pessoas na reserva.</param>
        /// <param name="dataEntrada">A data e hora de entrada da reserva.</param>
        /// <param name="mesaAlocada">A mesa alocada para a reserva.</param>
        /// <exception cref="InvalidOperationException">Lançada se a mesa já estiver ocupada ou se a capacidade for excedida.</exception>
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
        /// Finaliza a reserva, registrando a data e hora de saída e liberando a mesa.
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

        /// <summary>
        /// Recebe um pedido e adiciona os produtos ao pedido atual, se estiver aberto.
        /// </summary>
        /// <param name="produto">Lista de produtos a serem adicionados ao pedido.</param>
        /// <returns>Lista de produtos adicionados ao pedido.</returns>
        public List<Produto> ReceberPedido(List<Produto> produto)
        {
            if (pedido.PedidoAberto)
            {
                foreach (Produto p in produto)
                {
                    pedido.addItem(p);
                }
                return produto;
            }
            else
            {
                return produto;
            }

        }

        /// <summary>
        /// Retorna uma string que representa a reserva, incluindo o nome do cliente, data e hora de entrada e saída.
        /// </summary>
        /// <returns>Uma string representando a reserva.</returns>
        public override string ToString()
        {
            return $"Reserva: {Cliente.ToString()}. \nHorário de entrada: {DataEntrada:t} - Horário de saída: {DataSaida:t} ";
        }
    }
}