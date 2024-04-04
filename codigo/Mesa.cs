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
        private int IdMesa { get; set; }
        private int Capacidade { get; set; }
        public bool Ocupada { get; set; }
        #endregion

        #region Construtores
        public Mesa(int idMesa, int capacidade)
        {
            IdMesa = idMesa;
            Capacidade= capacidade;
            Ocupada= false;
        }
        #endregion

        #region Métodos
        //Verifica se a mesa está ocupada, e caso não esteja, o cliente que fez a requisição a ocupa
        public bool estahReserva()
        {
            if (Ocupada is false)
            {
                Ocupada = true;
                return Ocupada;
            }
            else
            {
                return Ocupada;
            }
        }
        #endregion
    }

}

