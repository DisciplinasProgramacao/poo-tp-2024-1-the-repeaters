using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Representa um produto com nome, valor e ID.
    /// </summary>
    public class Produto
    {
        #region Propriedades

        /// <summary>
        /// Obtém o nome do produto.
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Obtém o valor do produto.
        /// </summary>
        public double Valor { get; private set; }

        /// <summary>
        /// Obtém o ID do produto.
        /// </summary>
        public int Id { get; private set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="Produto"/> com os valores fornecidos.
        /// </summary>
        /// <param name="nome">O nome do produto.</param>
        /// <param name="valor">O valor do produto.</param>
        /// <param name="id">O ID do produto.</param>
        public Produto(string nome, double valor, int id)
        {
            Nome = nome;
            Valor = valor;
            Id = id;
        }

        #endregion

        public override string ToString()
        {
            return $"{Id}. {Nome} - R${Valor:F2} ";
        }
    }
}