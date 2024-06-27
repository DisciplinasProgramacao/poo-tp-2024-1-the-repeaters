using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Classe Cliente: Representa um cliente com um identificador único e um nome.
    /// </summary>
    public class Cliente
    {
        #region campos estáticos
        private static int proximoIdCliente = 1; // Contador para o próximo ID do cliente
        #endregion

        #region atributos
        private int idCliente; // Identificador único do cliente
        private string nome; // Nome do cliente
        #endregion

        #region construtor
        /// <summary>
        /// Cria um novo cliente com um identificador único e um nome.
        /// </summary>
        /// <param name="nome">Nome do cliente.</param>
        public Cliente(string nome)
        {
            this.idCliente = proximoIdCliente++;
            this.nome = nome;
        }
        #endregion

        #region métodos
        /// <summary>
        /// Retorna uma string que representa o cliente.
        /// </summary>
        /// <returns>String contendo o ID e o nome do cliente.</returns>
        public override string ToString()
        {
            return $"Cliente ID: {idCliente}, Nome: {nome}";
        }
        #endregion

        #region propriedades
        /// <summary>
        /// Obtém o identificador único do cliente.
        /// </summary>
        public int IdCliente { get { return idCliente; } }

        /// <summary>
        /// Obtém o nome do cliente.
        /// </summary>
        public string Nome { get { return nome; } }
        #endregion
    }
}