using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_POO
{
    internal class Restaurante
    {
        private List<Mesa> listaDeMesas;
        private List<Reserva> listaDeEspera;

        public Restaurante()
        {
            listaDeMesas = new List<Mesa>
            {
                new Mesa(1, 4), new Mesa(2, 4), new Mesa(3, 4), new Mesa(4, 4),
                new Mesa(5, 6), new Mesa(6, 6), new Mesa(7, 6), new Mesa(8, 6),
                new Mesa(9, 8), new Mesa(10, 8)
            };
            listaDeEspera = new List<Reserva>();
        }

        public void AlocarMesa(int quantPessoas)
        {
            Mesa mesaDisponivel = LocalizarMesa(quantPessoas);

            if (mesaDisponivel != null)
            {
                mesaDisponivel.ReservarMesa(); 
            }
            else
            {

                AdicionarListaEspera(new Reserva(quantPessoas));
            }
        }

        public Mesa LocalizarMesa(int capacidade)
        {
            foreach (Mesa mesa in listaDeMesas)
            {
                if (!mesa.Ocupada && mesa.Capacidade >= capacidade)
                {
                    return mesa;
                }
            }
            return null;
        }

        public void AdicionarListaEspera(Reserva reserva)
        {
            listaDeEspera.Add(reserva);
            Console.WriteLine("Cliente adicionado à lista de espera.");
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
                    Console.WriteLine($"Cliente removido da lista de espera e alocado na mesa {mesaDisponivel.IdMesa}.");
                    mesaDisponivel.ReservarMesa(); 
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
    }
}
