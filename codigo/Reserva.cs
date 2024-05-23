using System;
using System.Collections.Generic;

public class Reserva
{
    private int idReserva;
    private int quantPessoa;
    private DateTime dataEntrada;
    private DateTime? dataSaida;
    private Mesa mesaAlocada;
    private Cliente cliente;

    // Dicionário estático para rastrear o estado de ocupação das mesas
    private static Dictionary<int, bool> estadoMesas = new Dictionary<int, bool>();

    /// <summary>
    /// Construtor da classe Reserva.
    /// </summary>
    /// <param name="cliente">Cliente que fez a reserva.</param>
    /// <param name="idReserva">O identificador da reserva.</param>
    /// <param name="quantPessoa">A quantidade de pessoas na reserva.</param>
    /// <param name="dataEntrada">A data e hora de entrada da reserva.</param>
    /// <param name="mesaAlocada">A mesa alocada para a reserva.</param>
    public Reserva(Cliente cliente, int idReserva, int quantPessoa, DateTime dataEntrada, Mesa mesaAlocada)
    {
        Init(cliente, idReserva, quantPessoa, dataEntrada, mesaAlocada);
    }


    /// <summary>
    /// Inicializa a reserva com os parâmetros fornecidos.
    /// </summary>
    /// <param name="cliente">Cliente que fez a reserva.</param>
    /// <param name="idReserva">O identificador da reserva.</param>
    /// <param name="quantPessoa">A quantidade de pessoas na reserva.</param>
    /// <param name="dataEntrada">A data e hora de entrada da reserva.</param>
    /// <param name="mesaAlocada">A mesa alocada para a reserva.</param>
    private void Init(Cliente cliente, int idReserva, int quantPessoa, DateTime dataEntrada, Mesa mesaAlocada)
    {
        this.cliente = cliente;
        this.idReserva = idReserva;
        this.quantPessoa = quantPessoa;
        this.dataEntrada = dataEntrada;
        this.mesaAlocada = mesaAlocada;

        if (mesaAlocada != null)
        {
            // Verifica e atualiza o estado da mesa no dicionário
            if (!estadoMesas.ContainsKey(mesaAlocada.IdMesa))
            {
                estadoMesas[mesaAlocada.IdMesa] = false;
            }

            // A mesa é ocupada ao ser alocada para uma reserva
            if (estadoMesas[mesaAlocada.IdMesa] || !mesaAlocada.ocuparMesa(quantPessoa))
            {
                throw new InvalidOperationException("A mesa já está ocupada ou a capacidade é excedida.");
            }

            estadoMesas[mesaAlocada.IdMesa] = true;
        }
    }

    /// <summary>
    /// Método para finalizar a reserva.
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

        // Desocupa a mesa se alocada
        if (mesaAlocada != null)
        {
            mesaAlocada.ocuparMesa(0); // Utilize um valor neutro para desocupar a mesa
            estadoMesas[mesaAlocada.IdMesa] = false;
        }
    }

    internal void Init(Cliente cliente, int quantPessoas)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Propriedade somente leitura para obter a data de entrada da reserva.
    /// </summary>
    public DateTime DataEntrada
    {
        get { return dataEntrada; }
    }

    /// <summary>
    /// Propriedade somente leitura para obter a data de saída da reserva.
    /// </summary>
    public DateTime? DataSaida
    {
        get { return dataSaida; }
    }

    /// <summary>
    /// Propriedade somente leitura para obter a quantidade de pessoas na reserva.
    /// </summary>
    public int QuantPessoa
    {
        get { return quantPessoa; }
    }
}
