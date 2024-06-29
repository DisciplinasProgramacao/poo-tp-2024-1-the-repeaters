using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Classe Mesa: representa uma mesa em nosso restaurante
    /// </summary>
    public class Mesa
    {
        #region Atributos
        public int IdMesa { get; private set; }
        public int Capacidade { get; private set; }
        public bool Ocupada { get; private set; }
        #endregion

        #region Construtores
        /// <summary>
        /// Cria uma mesa pedindo o id e a capacidade, e inicializando ela como desocupada
        /// </summary>
        /// <param name="idMesa">ID da mesa</param>
        /// <param name="capacidade">Capacidade de pessoas que a mesa suporta</param>
        public Mesa(int idMesa, int capacidade)
        {
            IdMesa = idMesa;
            Capacidade = capacidade;
            Ocupada = false;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Verifica se a mesa está disponível
        /// Se não estiver, retorna falso
        /// </summary>
        /// <returns>O estado da mesa</returns>
        public bool EstahDisponivel()
        {
            return !Ocupada;
        }
        /// <summary>
        /// Ocupa a mesa.
        /// </summary>
        /// <param name="pessoas">Quantidade de pessoas que querem utilizar a mesa</param>
        /// <returns>Se a mesa foi ou não ocupada</returns>
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
        /// Verifica se a mesa suporta o número de pessoas que estão fazendo a requisição
        /// </summary>
        /// <param name="pessoas">Quantidade de pessoas que querem utilizar a mesa</param>
        /// <returns>Se a requisição pode ou não ser feita</returns>
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
        /// Libera a mesa.
        /// </summary>
        public void LiberarMesa()
        {
            Ocupada = false;
        }
        /// <summary>
        /// Fornece o estado da mesa.
        /// </summary>
        /// <returns>O estado atual da mesa</returns>
        public override string ToString()
        {
            return $"ID: {IdMesa}, Capacidade: {Capacidade}";
        }
        #endregion
    }
}