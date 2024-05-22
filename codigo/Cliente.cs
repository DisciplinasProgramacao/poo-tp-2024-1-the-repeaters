using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Cliente
    {
        private int idCliente; // Identificador único do cliente
        private string nome; // Nome do cliente

        /// <summary>
        /// Cria uma instância de Cliente com o ID e nome fornecidos.
        /// </summary>
        /// <param name="idCliente">O identificador único do cliente.</param>
        /// <param name="nome">O nome do cliente.</param>
        public Cliente(int idCliente, string nome)
        {
            this.idCliente = idCliente;
            this.nome = nome;
        }

        /// <summary>
        /// Sobrescreve o método ToString para retornar uma string que representa o cliente.
        /// </summary>
        /// <returns>Uma string que representa o cliente.</returns>
        public override string ToString()
        {
            return $"Cliente ID: {idCliente}, Nome: {nome}";
        }

        /// <summary>
        /// Faz uma reserva para o cliente em uma mesa com a capacidade especificada.
        /// </summary>
        /// <param name="capacidade">A mesa para a qual a reserva será feita.</param>
        /// <returns>A reserva associada ao cliente e à mesa.</returns>
        public Reserva FazerReserva(int capacidade)
        {
            // Crie uma nova reserva associada ao cliente e à capacidade da mesa
            Reserva reserva = new Reserva(this, capacidade);
            return reserva;
        }
        public int IdCliente { get { return IdCliente; } }
    }
}
