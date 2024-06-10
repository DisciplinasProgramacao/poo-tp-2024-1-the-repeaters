using System;
using System.Collections.Generic;
{
    internal class Cardapio
    {
        /// <summary>
        /// Lista de todos os itens do cardápio.
        /// </summary>
        private List<Produto> TodosItens;

        /// <summary>
        /// Construtor da classe Cardapio.
        /// Inicializa a lista de produtos disponíveis.
        /// </summary>
        public Cardapio()
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

        /// <summary>
        /// Exibe o cardápio completo com todas as comidas e bebidas disponíveis.
        /// </summary>
         public string MostrarCardapio()
         {
             StringBuilder sb = new StringBuilder();
        
             sb.AppendLine("Comidas:");
             foreach (var item in TodosItens)
             {
                 if (item.Id <= 6)
                 {
                     sb.AppendLine($"{item.Id}. {item.Nome} – R$ {item.Valor}");
                 }
             }
        
             sb.AppendLine("\nBebidas:");
             foreach (var item in TodosItens)
             {
                 if (item.Id > 6)
                 {
                     sb.AppendLine($"{item.Id}. {item.Nome} – R$ {item.Valor}");
                 }
             }
        
             return sb.ToString();
         }
      
        /// <summary>
        /// Gera um pedido baseado na lista de itens selecionados e adiciona os produtos na lista fornecida.
        /// </summary>
        /// <param name="idsProdutos">Lista de identificadores dos produtos selecionados.</param>
        /// <param name="pedido">Lista de produtos onde os itens do pedido serão adicionados.</param>
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
    }
}

