using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Classe abstrata que representa um estabelecimento com clientes cadastrados e um cardápio.
    /// </summary>
    public abstract class Estabelecimento
    {
        #region Atributos

        /// <summary>
        /// Lista de clientes cadastrados no estabelecimento.
        /// </summary>
        protected List<Cliente> clientesCadastrados;

        /// <summary>
        /// Interface para o cardápio do estabelecimento.
        /// </summary>
        public ICardapio Cardapio { get; protected set; }

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor que inicializa o estabelecimento com um cardápio.
        /// </summary>
        /// <param name="cardapio">O cardápio do estabelecimento.</param>
        public Estabelecimento(ICardapio cardapio)
        {
            clientesCadastrados = new List<Cliente>();
            Cardapio = cardapio;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Cadastra um novo cliente no estabelecimento.
        /// </summary>
        /// <param name="nome">Nome do cliente.</param>
        /// <returns>O novo cliente cadastrado.</returns>
        public Cliente CadastrarCliente(string nome)
        {
            Cliente novoCliente = new Cliente(nome);
            clientesCadastrados.Add(novoCliente);
            return novoCliente;
        }

        /// <summary>
        /// Localiza um cliente pelo nome.
        /// </summary>
        /// <param name="nome">Nome do cliente.</param>
        /// <returns>O cliente encontrado ou null se não encontrado.</returns>
        public Cliente LocalizarCliente(string nome)
        {
            return clientesCadastrados.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Localiza um cliente pelo ID.
        /// </summary>
        /// <param name="idCliente">ID do cliente.</param>
        /// <returns>O cliente encontrado ou null se não encontrado.</returns>
        public Cliente LocalizarClientePorId(int idCliente)
        {
            return clientesCadastrados.FirstOrDefault(c => c.IdCliente == idCliente);
        }

        /// <summary>
        /// Método abstrato para fazer um pedido.
        /// </summary>
        /// <param name="idReserva">ID da reserva.</param>
        /// <param name="ids">IDs dos itens do pedido.</param>
        public abstract void FazerPedido(string idReserva, string ids);

        /// <summary>
        /// Exibe o cardápio do estabelecimento.
        /// </summary>
        /// <returns>Uma string representando o cardápio.</returns>
        public string VerCardapio()
        {
            return Cardapio.MostrarCardapio();
        }

        #endregion
    }
}