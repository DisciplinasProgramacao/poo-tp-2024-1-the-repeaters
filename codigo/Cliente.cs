using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_POO
{
    /// <summary>
    /// Representa um cliente no sistema.
    /// </summary>
    public class Cliente
    {
        #region Atributos estáticos
        private static int proximoIdCliente = 1; // Usado para gerar IDs automáticos para os clientes.
        #endregion

        #region Atributos de instância
        private int idCliente; // ID único do cliente.
        private string nome; // Nome do cliente.
        #endregion

        #region Construtores
        /// <summary>
        /// Inicializa uma nova instância da classe Cliente com um nome específico.
        /// </summary>
        /// <param name="nome">O nome do cliente.</param>
        public Cliente(string nome)
        {
            this.idCliente = proximoIdCliente++; // Gera automaticamente o ID do cliente.
            this.nome = nome;
        }
        #endregion

        #region Métodos sobrescritos
        /// <summary>
        /// Retorna uma string que representa o cliente.
        /// </summary>
        /// <returns>Uma string que representa o cliente com seu ID e nome.</returns>
        public override string ToString()
        {
            return $"Cliente ID: {idCliente}, Nome: {nome}";
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Obtém o ID do cliente.
        /// </summary>
        public int IdCliente { get { return idCliente; } }

        /// <summary>
        /// Obtém o nome do cliente.
        /// </summary>
        public string Nome { get { return nome; } }
        #endregion
    }
}
