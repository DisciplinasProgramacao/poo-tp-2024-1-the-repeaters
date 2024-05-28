   public class Mesa
{
    #region Atributos
    public int IdMesa { get; private set; }
    public int Capacidade { get; private set; }
    public bool Ocupada { get; private set; }
    #endregion

    #region Construtores
    ///<summary>
    /// Construtor base para criar uma mesa, necessitando passar seu ID e sua capacidade.
    /// A variável ocupada se inicia originalmente como false.
    ///</summary>
    ///<param name="idMesa"> ID gerado para a mesa criada</param>
    ///<param name="capacidade"> A capacidade de clientes da mesa criada</param>
    public Mesa(int idMesa, int capacidade)
    {
        IdMesa = idMesa;
        Capacidade = capacidade;
        Ocupada = false;
    }
    #endregion

    #region Métodos
    ///<summary>
    /// Verifica se a mesa está disponível.
    /// Se a mesa já está ocupada, retorna como falso.
    ///</summary>
    ///<returns> O boolean com o estado da mesa</returns>
    public bool EstahDisponivel()
    {
        return !Ocupada;
    }

    /// <summary>
    /// Se o número de pessoas atende a capacidade da mesa, a ocupa.
    /// Se já está ocupada ou a capacidade é excedida, retorna falso.
    /// </summary>
    /// <param name="pessoas">Número de pessoas que querem ocupar a mesa</param>
    /// <returns>O estado atual da mesa após a tentativa de ocupação</returns>
    public bool OcuparMesa(int pessoas)
    {
        if (verificarRequisicao(pessoas))
        {
            Ocupada = true;
            return true;
        }
        return false;
    }
    /// <summary>
    /// Verifica se a mesa suporta a capacidade de pessoas que a quer ocupar.
    /// </summary>
    /// <param name="pessoas">Número de pessoas que quer ocupar a mesa</param>
    /// <returns>True se a mesa suporta a capacidade, false caso contrário</returns>
    private bool verificarRequisicao(int pessoas)
    {
        if (pessoas >= Capacidade && Ocupada != false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// Libera a mesa, a desocupando.
    /// </summary>
    public void LiberarMesa()
    {
        Ocupada = false;
    }

    /// <summary>
    /// ToString informando o ID da mesa, a capacidade que ela suporta e se está ocupada ou não
    /// </summary>
    public override string ToString()
    {
        return $"ID da mesa: {IdMesa}, Capacidade: {Capacidade}, Ocupação: {Ocupada}";
    }
}
#endregion
