using System;

/// <summary>
/// Representa um cliente do restaurante.
/// </summary>
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
}
