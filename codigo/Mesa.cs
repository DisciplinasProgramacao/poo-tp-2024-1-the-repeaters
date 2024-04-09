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
    ///Verifica se a mesa está ocupada, e caso não esteja, o cliente que fez a requisição a ocupa.
    ///Se a mesa já está ocupada, retorna como falso e não é realizada a reserva
    ///</summary>
    ///<returns> O boolean com o estado da mesa</returns>
    public bool estahReserva()
    {
        if (_ocupada == false)
        {
            _ocupada = true;
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Getters e Setters
    public int Capacidade { get { return _capacidade; } set { _capacidade = value; } }

    public int IdMesa { get { return _idMesa; } set { _idMesa = value; } }
    #endregion
}

