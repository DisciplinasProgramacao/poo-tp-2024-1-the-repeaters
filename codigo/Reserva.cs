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
    private Pedido pedido;
    
    public Reserva(Cliente cliente, int idReserva, int quantPessoa, DateTime dataEntrada, Mesa mesaAlocada)
    {
        this.cliente = cliente;
        this.idReserva = idReserva;
        this.quantPessoa = quantPessoa;
        this.dataEntrada = dataEntrada;
        this.mesaAlocada = mesaAlocada;
        this.pedido = new Pedido();
    
        if (mesaAlocada != null)
        {
            if (!mesaAlocada.OcuparMesa(quantPessoa))
            {
                throw new InvalidOperationException("A mesa já está ocupada ou a capacidade é excedida.");
            }
        }
    }
    
    public void FinalizarReserva(DateTime horaSaida)
    {
        if (dataSaida.HasValue)
        {
            throw new InvalidOperationException("Esta reserva já foi finalizada.");
        }
    
        dataSaida = horaSaida;
    
        if (mesaAlocada != null)
        {
            mesaAlocada.LiberarMesa();
        }
    }
    
    public Pedido Pedido { get { return pedido; } }
    public DateTime DataEntrada { get { return dataEntrada; } }
    public DateTime? DataSaida { get { return dataSaida; } }
    public int QuantPessoa { get { return quantPessoa; } }
    public int IdReserva { get { return idReserva; } }
    public Cliente Cliente { get { return cliente; } }
    public Mesa MesaAlocada { get { return mesaAlocada; } set { mesaAlocada = value; } }
}
