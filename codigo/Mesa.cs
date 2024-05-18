class Mesa
{
    #region Atributos
    private int _idMesa;
    private int _capacidade;
    private bool _ocupada;

    #endregion

    #region Construtores
    ///<summary>
    ///Construtor base para criar uma mesa, necessitando passar seu ID e sua capacidade.
    ///A variável ocupada se inicia originalmente como false.
    ///</summary>
    ///<param name="idMesa"> ID gerado para a mesa criada
    ///<param name="capacidade"> A capacidade de clientes da mesa criada
    public Mesa(int idMesa, int capacidade)
    {
        _idMesa = idMesa;
        _capacidade = capacidade;
        _ocupada = false;
    }
    #endregion

    #region Métodos
    ///<summary>
    ///Verifica se a mesa está disponível.
    ///Se a mesa já está ocupada, retorna como falso
    ///Alterações: alterei para que ele verifique se a mesa está disponível ao invés de verificar se está ocupada, para não causar confusão.
    ///</summary>
    ///<returns> O boolean com o estado da mesa</returns>
    public bool estahDisponivel()
    {
        if (_ocupada == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Se o número de pessoas atende a capacidade da mesa, a ocupa.
    /// Se já está ocupada, apenas retorna falso para a requisição
    /// </summary>
    /// <returns>O estado atual da mesa após a tentativa de ocupação</returns>
    /// <summary>
    /// Se o número de pessoas atende a capacidade da mesa, a ocupa.
    /// Se já está ocupada ou a capacidade é excedida, retorna falso.
    /// </summary>
    /// <param name="pessoas">Número de pessoas que querem ocupar a mesa</param>
    /// <returns>O estado atual da mesa após a tentativa de ocupação</returns>
    public bool ocuparMesa(int pessoas)
    {
        if (!_ocupada && verificarRequisicao(pessoas))
        {
            _ocupada = true;
            return true;
        }
         else return false;
    }
    /// <summary>
    /// Verifica se a mesa suporta a capacidade de pessoas que a quer ocupar
    /// </summary>
    /// <param name="pessoas">Número de pessoas que quer ocupar a mesa</param>
    /// <returns></returns>
    private bool verificarRequisicao(int pessoas)
    {
        if (pessoas > _capacidade)
        {
            return false;
        }
        else 
        {
            return true;
        }
    }
    #endregion

    #region Getters
    public int Capacidade { get { return _capacidade; } }

    public int IdMesa { get { return _idMesa; } }
    #endregion
}
