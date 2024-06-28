using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Interface para representar um cardápio.
    /// </summary>
    public interface ICardapio
    {
        #region Métodos

        /// <summary>
        /// Exibe o cardápio.
        /// </summary>
        /// <returns>String representando o cardápio.</returns>
        string MostrarCardapio();

        /// <summary>
        /// Gera um pedido com base nos IDs dos produtos selecionados.
        /// </summary>
        /// <param name="idsProdutos">Lista de IDs dos produtos selecionados.</param>
        /// <param name="pedido">Lista de produtos que compõem o pedido.</param>
        /// <returns>Lista de produtos que compõem o pedido atualizado.</returns>
        List<Produto> GerarPedido(List<int> idsProdutos, List<Produto> pedido);

        #endregion
    }
}