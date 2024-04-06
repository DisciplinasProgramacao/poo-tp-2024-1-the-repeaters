using System;

public class Cliente
{
    // Atributos
    private int idCliente;
    private string nome;

    // Construtor do "Cliente"
    public Cliente(int idCliente, string nome)
    {
        this.idCliente = idCliente;
        this.nome = nome;
    }

    // Método para fazer a reserva
    public Reserva FazerReserva(Mesa capacidade)
    {
        // Criar uma nova reserva
        Reserva reserva = new Reserva(this, capacidade);
        return reserva;
    }
}