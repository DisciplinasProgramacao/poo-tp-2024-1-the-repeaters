using POO3;
using System;
using System.Collections.Generic;

namespace POO3
{
    public class Restaurante
    {
        private List<Mesa> listaDeMesas;
        private List<Reserva> listaDeEspera;
        private List<Reserva> reservasAtivas;

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

        public Reserva ObterReserva(int idReserva)
        {
            Reserva reserva = reservasAtivas.Find(r => r.IdReserva == idReserva);
            if (reserva == null)
            {
                Console.WriteLine("Reserva não encontrada.");
            }
            return reserva;
        }

        public void FinalizarReserva(int idReserva, DateTime horaSaida)
        {
            Reserva reserva = ObterReserva(idReserva);
            if (reserva != null)
            {
                reserva.FinalizarReserva(horaSaida);
                reservasAtivas.Remove(reserva);

                Console.WriteLine($"Reserva ID: {reserva.IdReserva} finalizada. Mesa {reserva.MesaAlocada.IdMesa} agora está disponível.");

                // Tentar alocar o próximo cliente da fila de espera
                RemoverClienteListaEspera();
            }
        }
    }
}
