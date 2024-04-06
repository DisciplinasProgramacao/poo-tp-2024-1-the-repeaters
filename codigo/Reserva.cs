using System;
{
    internal class Reserva
    {
        private int idReserva;
        private int quantPessoa;
        private DateTime dataEntrada;
        private DateTime? dataSaida;
        private Mesa mesaAlocada;

        /// <summary>
        /// Construtor da classe Reserva.
        /// </summary>
        /// <param name="idReserva">O identificador da reserva.</param>
        /// <param name="quantPessoa">A quantidade de pessoas na reserva.</param>
        /// <param name="dataEntrada">A data e hora de entrada da reserva.</param>
        /// <param name="mesaAlocada">A mesa alocada para a reserva.</param>
        public Reserva(int idReserva, int quantPessoa, DateTime dataEntrada, Mesa mesaAlocada)
        {
            this.idReserva = idReserva;
            this.quantPessoa = quantPessoa;
            this.dataEntrada = dataEntrada;
            this.mesaAlocada = mesaAlocada;
        }

        /// <summary>
        /// Método para finalizar a reserva e liberar a mesa.
        /// </summary>
        /// <returns>A data e hora de saída da reserva.</returns>
        /// <summary>
        /// Método para finalizar a reserva e liberar a mesa.
        /// </summary>
        /// <param name="horaSaida">A hora de saída da reserva.</param>
        public void FinalizarReserva(DateTime horaSaida)
        {
            // Verifica se a reserva já foi finalizada
            if (dataSaida.HasValue)
            {
                throw new InvalidOperationException("Esta reserva já foi finalizada.");
            }

            // Registra a hora de saída
            dataSaida = horaSaida;

            // Libera a mesa
            mesaAlocada.Disponivel = true;
        }
        /// <summary>
        /// Propriedade somente leitura para obter a data de entrada da reserva.
        /// </summary>
        public DateTime DataEntrada
        {
            get { return dataEntrada; }
        }
        /// <summary>
        /// Propriedade somente leitura para obter a data de saida da reserva.
        /// </summary>
        public DateTime? DataSaida
        {
            get { return dataSaida; }
        }
    }
}
