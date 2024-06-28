using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Representa o cardápio do restaurante.
    /// </summary>
    public class CardapioRestaurante : ICardapio
    {
        #region Atributos

        private List<Produto> TodosItens;

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="CardapioRestaurante"/> com itens predefinidos.
        /// </summary>
        public CardapioRestaurante()
        {
            TodosItens = new List<Produto>
            {
                new Produto("Moqueca de Palmito", 32, 1),
                new Produto("Falafel Assado", 20, 2),
                new Produto("Salada Primavera com Macarrão Konjac", 25, 3),
                new Produto("Escondidinho de Inhame", 18, 4),
                new Produto("Strogonoff de Cogumelos", 35, 5),
                new Produto("Caçarola de legumes", 22, 6),
                new Produto("Água", 3, 7),
                new Produto("Copo de suco", 7, 8),
                new Produto("Refrigerante orgânico", 7, 9),
                new Produto("Cerveja vegana", 9, 10),
                new Produto("Taça de vinho vegano", 18, 11)
            };
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Exibe o cardápio do restaurante.
        /// </summary>
        /// <returns>Uma string representando o cardápio.</returns>
        public string MostrarCardapio()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Comidas:");
            foreach (var item in TodosItens)
            {
                if (item.Id <= 6)
                {
                    sb.AppendLine($"{item.ToString()}");
                }
            }

            sb.AppendLine("\nBebidas:");
            foreach (var item in TodosItens)
            {
                if (item.Id > 6)
                {
                    sb.AppendLine($"{item.ToString()}");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gera um pedido com base nos IDs dos produtos selecionados.
        /// </summary>
        /// <param name="idsProdutos">Lista de IDs dos produtos selecionados.</param>
        /// <param name="pedido">Lista de produtos que compõem o pedido.</param>
        /// <returns>Lista de produtos que compõem o pedido atualizado.</returns>
        public List<Produto> GerarPedido(List<int> idsProdutos, List<Produto> pedido)
        {
            List<Produto> produtosAdicionados = new List<Produto>();
            foreach (int id in idsProdutos)
            {
                Produto produto = TodosItens.Find(item => item.Id == id);
                if (produto != null)
                {
                    pedido.Add(produto);
                    produtosAdicionados.Add(produto);
                }
            }
            return produtosAdicionados;
        }

        #endregion
    }
}