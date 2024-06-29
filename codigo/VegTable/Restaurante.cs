using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Representa um restaurante com funcionalidades de reservas e gestão de mesas.
    /// </summary>
    public class Restaurante : Estabelecimento
    {
        private List<Mesa> listaDeMesas;
        private List<Reserva> listaDeEspera;
        private List<Reserva> reservasAtivas;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Restaurante"/>.
        /// </summary>
        public Restaurante() : base(new CardapioRestaurante())
        {
            listaDeMesas = new List<Mesa>
            {
                new Mesa(1, 4), new Mesa(2, 4), new Mesa(3, 4), new Mesa(4, 4),
                new Mesa(5, 6), new Mesa(6, 6), new Mesa(7, 6), new Mesa(8, 6),
                new Mesa(9, 8), new Mesa(10, 8)
            };
            listaDeEspera = new List<Reserva>();
            reservasAtivas = new List<Reserva>();
        }

        /// <summary>
        /// Faz uma reserva para o restaurante.
        /// </summary>
        /// <param name="nomeReserva">Nome da reserva.</param>
        /// <param name="numPessoas">Número de pessoas na reserva.</param>
        /// <returns>Uma string contendo os detalhes da reserva.</returns>
        /// <exception cref="Exception">Lança uma exceção se o nome da reserva ou o número de pessoas forem inválidos, ou se o cliente não estiver cadastrado.</exception>
        public string FazerReserva(string nomeReserva, int numPessoas)
        {
            if (string.IsNullOrEmpty(nomeReserva))
            {
                throw new InvalidOperationException("Nome inválido.");
            }

            if (numPessoas <= 0)
            {
                throw new InvalidOperationException("Número de pessoas inválido.");
            }

            Cliente cliente = LocalizarCliente(nomeReserva);
            if (cliente == null)
            {
                throw new InvalidOperationException("Cliente não cadastrado. Por favor, cadastre o cliente antes de fazer a reserva.");
            }

            Mesa mesaDisponivel = LocalizarMesa(numPessoas);
            int idReserva = reservasAtivas.Count + 1;

            if (mesaDisponivel != null)
            {
                Reserva reserva = new Reserva(cliente, idReserva, numPessoas, DateTime.Now, mesaDisponivel);
                reservasAtivas.Add(reserva);
                return $"Reserva ID: {reserva.IdReserva} - Mesa alocada para Cliente ID: {cliente.ToString()} na mesa {mesaDisponivel.ToString()} lugares.";
            }
            else
            {
                Reserva reserva = new Reserva(cliente, idReserva, numPessoas, DateTime.Now, null);
                AdicionarListaEspera(reserva);
                return $"Reserva ID: {reserva.IdReserva} - Cliente adicionado à lista de espera.";
            }
        }

        /// <summary>
        /// Realiza um pedido para uma reserva específica.
        /// </summary>
        /// <param name="idReserva">ID da reserva.</param>
        /// <param name="ids">IDs dos produtos do pedido, separados por vírgula.</param>
        /// <exception cref="Exception">Lança uma exceção se o ID da reserva ou os IDs dos produtos forem inválidos, ou se a reserva não for encontrada.</exception>
        public override void FazerPedido(string idReserva, string ids)
        {
            if (string.IsNullOrEmpty(idReserva) || !int.TryParse(idReserva, out int idReservaPedido))
            {
                throw new InvalidOperationException("ID de reserva inválido.");
            }

            Reserva reserva = ObterReserva(idReservaPedido);
            if (reserva == null)
            {
                throw new ArgumentException("Reserva não encontrada ou pedido já fechado.");
            }

            if (string.IsNullOrEmpty(ids))
            {
                throw new ArgumentNullException("IDs de produtos inválidos.");
            }

            List<int> idsProdutos = ids.Split(',').Select(id => int.Parse(id.Trim())).ToList();

            List<Produto> produtosAdicionados = reserva.ReceberPedido(Cardapio.GerarPedido(idsProdutos, reserva.Pedido.Itens));

            if (produtosAdicionados.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Produtos adicionados ao pedido:");
                foreach (var produto in produtosAdicionados)
                {
                    sb.AppendLine($"- {produto.ToString()}");
                }
                Console.WriteLine(sb.ToString());
            }
            else
            {
                throw new ArgumentNullException("Nenhum produto válido foi adicionado ao pedido.");
            }
        }

        /// <summary>
        /// Finaliza uma reserva específica.
        /// </summary>
        /// <param name="idReserva">ID da reserva.</param>
        /// <exception cref="Exception">Lança uma exceção se o ID da reserva for inválido, ou se a reserva não for encontrada.</exception>
        public Reserva FinalizarReserva(string idReserva)
        {
            if (string.IsNullOrEmpty(idReserva))
            {
                throw new ArgumentNullException("ID de reserva inválido.");
            }

            int idReservaFinalizar = int.Parse(idReserva);
            Reserva reserva = ObterReserva(idReservaFinalizar);
            if (reserva != null)
            {
                reserva.FinalizarReserva(DateTime.Now);
                reservasAtivas.Remove(reserva);

                double valorPorPessoa = reserva.Pedido.CalcularTotal() / reserva.QuantPessoa;

                StringBuilder sb = new StringBuilder();
                sb.Append("\n");
                sb.AppendLine("Conta Fechada - Detalhes do Pedido:");
                sb.Append("\n");
                sb.AppendLine($"Valor do Pedido: R$ {reserva.Pedido.CalcularPedido():F2}");
                sb.AppendLine($"Valor da Taxa do Serviço: R$ {reserva.Pedido.CalcularTaxa():F2}");
                sb.Append("\n");
                sb.AppendLine($"Valor do Total: R$ {reserva.Pedido.CalcularTotal():F2}");
                sb.AppendLine($"Valor por Pessoa: R$ {valorPorPessoa:F2}");

                RemoverClienteListaEspera();

                Console.WriteLine(sb.ToString());
                return reserva;
            }
            else
            {
                throw new InvalidOperationException("Reserva não encontrada.");
            }
        }

        /// <summary>
        /// Localiza uma mesa disponível com capacidade suficiente.
        /// </summary>
        /// <param name="capacidade">Capacidade mínima da mesa.</param>
        /// <returns>Uma instância de <see cref="Mesa"/> disponível, ou null se nenhuma mesa estiver disponível.</returns>
        public Mesa LocalizarMesa(int capacidade)
        {
            foreach (Mesa mesa in listaDeMesas)
            {
                if (mesa.EstahDisponivel() && mesa.Capacidade >= capacidade)
                {
                    return mesa;
                }
            }
            return null;
        }

        /// <summary>
        /// Adiciona uma reserva à lista de espera.
        /// </summary>
        /// <param name="reserva">A reserva a ser adicionada à lista de espera.</param>
        private void AdicionarListaEspera(Reserva reserva)
        {
            listaDeEspera.Add(reserva);
        }

        /// <summary>
        /// Remove um cliente da lista de espera e o aloca em uma mesa disponível.
        /// </summary>
        public void RemoverClienteListaEspera()
        {
            if (listaDeEspera.Count > 0)
            {
                Reserva reserva = listaDeEspera[0];
                listaDeEspera.RemoveAt(0);

                Mesa mesaDisponivel = LocalizarMesa(reserva.QuantPessoa);
                if (mesaDisponivel != null)
                {
                    reserva.MesaAlocada = mesaDisponivel;
                    reservasAtivas.Add(reserva);
                    mesaDisponivel.OcuparMesa(reserva.QuantPessoa);
                }
            }
        }

        /// <summary>
        /// Mostra a lista de espera.
        /// </summary>
        /// <returns>Uma string contendo os detalhes das reservas na lista de espera.</returns>
        /// <exception cref="Exception">Lança uma exceção se a lista de espera estiver vazia.</exception>
        public string MostrarListaDeEspera()
        {
            StringBuilder listaEsperaBuilder = new StringBuilder();

            if (listaDeEspera.Count > 0)
            {
                listaEsperaBuilder.AppendLine("Lista de Espera:");
                foreach (var reserva in listaDeEspera)
                {
                    listaEsperaBuilder.AppendLine($"Reserva ID: {reserva.IdReserva} - {reserva.Cliente.ToString()}, Pessoas: {reserva.QuantPessoa}");
                }
            }
            else
            {
                throw new ArgumentNullException("A lista de espera está vazia.");
            }

            return listaEsperaBuilder.ToString();
        }

        /// <summary>
        /// Obtém uma reserva específica pelo seu ID.
        /// </summary>
        /// <param name="idReserva">ID da reserva.</param>
        /// <returns>A instância de <see cref="Reserva"/> correspondente ao ID.</returns>
        public Reserva ObterReserva(int idReserva)
        {
            return reservasAtivas.Find(r => r.IdReserva == idReserva);
        }

        /// <summary>
        /// Mostra os clientes atualmente nas mesas.
        /// </summary>
        /// <returns>Uma string contendo os detalhes dos clientes nas mesas.</returns>
        /// <exception cref="Exception">Lança uma exceção se não houver clientes nas mesas.</exception>
        public string MostrarClientesNasMesas()
        {
            StringBuilder clientesNasMesasBuilder = new StringBuilder();

            if (reservasAtivas.Count > 0)
            {
                clientesNasMesasBuilder.AppendLine("Clientes nas Mesas:");
                foreach (var reserva in reservasAtivas)
                {
                    clientesNasMesasBuilder.AppendLine($"Reserva ID: {reserva.IdReserva} - {reserva.Cliente.ToString()}, Mesa: {reserva.MesaAlocada.ToString()}, Pessoas: {reserva.QuantPessoa}");
                }
            }
            else
            {
                throw new ArgumentNullException("Nenhum cliente está nas mesas.");
            }

            return clientesNasMesasBuilder.ToString();
        }
    }
}