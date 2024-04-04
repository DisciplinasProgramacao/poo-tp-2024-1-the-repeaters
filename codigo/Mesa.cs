using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Mesa
    {
        #region Atributos
        private int _idMesa; 
        private int _capacidade; 
        private bool _ocupada; 
        #endregion

        #region Construtores
        public Mesa(int idMesa, int capacidade)
        {
            _idMesa = idMesa;
            _capacidade= capacidade;
            _ocupada= false;
        }
        #endregion

        #region Métodos
        //Verifica se a mesa está ocupada, e caso não esteja, o cliente que fez a requisição a ocupa
        public bool estahReserva()
        {
            if (_ocupada is false)
            {
                _ocupada = true;
                return _ocupada;
            }
            else
            {
                return _ocupada;
            }
        }
        #endregion
    }

}

