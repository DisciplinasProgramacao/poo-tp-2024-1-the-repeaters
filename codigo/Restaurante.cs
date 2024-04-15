using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main___POO
{

    internal class Restaurante
    {
        private List<Mesa> listaDeMesas;
        private Queue<Reserva> FilaDeEspera;

        /// <summary>
        /// Construtor da classe restaurante 
        /// </summary>
        /// <param name="listadeMesas">Listas de mesas</param>
        /// <param name="FiladeEspera">Fila de espera para clientes</param>
        public Restaurante(List<Mesa> mesas)
        {
            listaDeMesas = mesas;
            FilaDeEspera = new Queue<Reserva>();
        }
        /// <summary>
        /// Metodo para alocar o cliente em uma mesa, caso nao tenha vaga adiciona a fila de espera.
        /// </summary>
        /// <param name="quantPessoas">Quantidade de pessoas para alocar a mesa</param>
        public void AlocarMesa(int quantPessoas)
        {

            Mesa mesaDisponivel = null;
            int idReserva = 0;

            if (LocalizarMesa(quantPessoas) != null)
            {
                mesaDisponivel.estahReserva();
                Console.WriteLine($"Mesa {mesaDisponivel.IdMesa} alocada para {quantPessoas} pessoas.");
            }
            else
            {
                Console.WriteLine("Não há mesas disponíveis no momento. Adicionando à fila de espera.");
                idReserva += 1;
                Reserva reserva = new Reserva(quantPessoas);
                AdicionarFilaEspera(reserva);
                
            }
        }

        /// <summary>
        /// Metodo para localizar uma mesa com base na capacidade que ela pode alocar. 
        /// </summary>
        /// <param name="capacidade">Quantidade de pessoas que a mesa pode alocar</param>
        /// <returns></returns>
        public Mesa LocalizarMesa(int capacidade)
        {
            foreach (Mesa mesa in listaDeMesas)
            {
                if (mesa.estahReserva() && mesa.Capacidade >= capacidade)
                {
                    return mesa; 
                }
            }
            return null; 
        }

        /// <summary>
        /// Metodo para adicionar o cliente a uma fila de espera.
        /// </summary>
        /// <param name="reserva">Cria uma reserva para o cleinte</param>
        public void AdicionarFilaEspera(Reserva reserva)
        {
            FilaDeEspera.Enqueue(reserva);
            Console.WriteLine("Cliente adicionado à fila de espera.");
        }

        /// <summary>
        /// Metodo para remover o cliente da fila de espera, quando a mesa ficar livre.
        /// </summary>
        public void RemoverClienteFila()
        {
            if (FilaDeEspera.Count > 0)
            {
                Reserva reserva = FilaDeEspera.Dequeue();
                Console.WriteLine("Cliente removido da fila de espera.");
            }
            else
            {
                Console.WriteLine("A fila de espera está vazia.");
            }
        }
    }
}
