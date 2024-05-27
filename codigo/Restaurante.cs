    public class Restaurante
    {
        private List<Mesa> listaDeMesas;
        private List<Reserva> listaDeEspera;
        private List<Reserva> reservasAtivas;
        public Cardapio Cardapio { get;private set; }

        public Restaurante()
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

        public void AlocarMesa(Cliente cliente, int quantPessoas)
        {
            Mesa mesaDisponivel = LocalizarMesa(quantPessoas);
            int idReserva = reservasAtivas.Count + 1;

            if (mesaDisponivel != null)
            {
                Reserva reserva = new Reserva(cliente, idReserva, quantPessoas, DateTime.Now, mesaDisponivel);
                reservasAtivas.Add(reserva);
                Console.WriteLine($"Reserva ID: {reserva.IdReserva} - Mesa alocada para Cliente ID: {cliente.IdCliente}, Nome: {cliente.Nome} na mesa {mesaDisponivel.IdMesa} com {mesaDisponivel.Capacidade} lugares.");
            }
            else
            {
                Reserva reserva = new Reserva(cliente, idReserva, quantPessoas, DateTime.Now, null);
                AdicionarListaEspera(reserva);
            }
        }

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

        public Mesa LocalizarMesaPorId(int idMesa)
        {
            return listaDeMesas.Find(m => m.IdMesa == idMesa);
        }

        private void AdicionarListaEspera(Reserva reserva)
        {
            listaDeEspera.Add(reserva);
            Console.WriteLine($"Reserva ID: {reserva.IdReserva} - Cliente adicionado à lista de espera.");
        }

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
                    Console.WriteLine($"Reserva ID: {reserva.IdReserva} - Cliente removido da lista de espera e alocado na mesa {mesaDisponivel.IdMesa} com {mesaDisponivel.Capacidade} lugares.");
                }
                else
                {
                    Console.WriteLine("Não há mesas disponíveis para o cliente removido da lista de espera.");
                }
            }
            else
            {
                Console.WriteLine("A lista de espera está vazia.");
            }
        }

        public void MostrarListaDeEspera()
        {
            if (listaDeEspera.Count > 0)
            {
                Console.WriteLine("Lista de Espera:");
                foreach (var reserva in listaDeEspera)
                {
                    Console.WriteLine($"Reserva ID: {reserva.IdReserva} - Cliente ID: {reserva.Cliente.IdCliente}, Nome: {reserva.Cliente.Nome}, Pessoas: {reserva.QuantPessoa}");
                }
            }
            else
            {
                Console.WriteLine("A lista de espera está vazia.");
            }
        }

        public Reserva ObterReserva(int idReserva)
        {
            Reserva? reserva = reservasAtivas.Find(r => r.IdReserva == idReserva);
            if (reserva == null)
            {
                Console.WriteLine("Reserva não encontrada.");
            }
            return reserva;
        }

        public void CancelarReserva(int idReserva)
        {
            Reserva reserva = ObterReserva(idReserva);
            if (reserva != null)
            {
                if (reserva.MesaAlocada != null)
                {
                    reserva.MesaAlocada.LiberarMesa();
                }
                reservasAtivas.Remove(reserva);
                Console.WriteLine($"Reserva ID: {idReserva} foi cancelada.");
            }
        }

        public void FinalizarReserva(int idReserva, DateTime horaSaida)
        {
            Reserva reserva = ObterReserva(idReserva);
            if (reserva != null)
            {
                reserva.FinalizarReserva(horaSaida);
                reservasAtivas.Remove(reserva);

                Console.WriteLine($"Reserva ID: {reserva.IdReserva} finalizada. Mesa {reserva.MesaAlocada.IdMesa} agora está disponível.");

                RemoverClienteListaEspera();
            }
        }
        /// <summary>
        /// Exibe o cardápio, os produtos oferecidos e o preço respectivo.
        /// </summary>
        public void VerCardapio()
        {
            Cardapio.MostrarCardapio();
        }

        /// <summary>
        /// Procura a reserva para incluir um produto no pedido, e se ela existir, gera o pedido
        /// </summary>
        /// <param name="idReserva">id da reserva de quem quer o item</param>
        /// <param name="idsProdutos">produtos pedidos que serão adicionados</param>
        /// <returns>uma lista de produtos</returns>
        public List<Produto> IncluirProduto(int idReserva, List<int>idsProdutos)
        {
            Reserva reserva = ObterReserva(idReserva);

            if (reserva != null) { return Cardapio.GerarPedido(idsProdutos, reserva.Pedido.Itens); }
            else 
            {
                Console.WriteLine("Reserva não encontrada!"); 
                return new List<Produto>();
            }
        }
    }
