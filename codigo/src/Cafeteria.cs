using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    /// <summary>
    /// Classe que representa uma cafeteria, derivada da classe Estabelecimento.
    /// </summary>
    public class Cafeteria : Estabelecimento
    {
        #region Construtor

        /// <summary>
        /// Construtor que inicializa a cafeteria com o cardápio específico de uma cafeteria.
        /// </summary>
        public Cafeteria() : base(new CardapioCafeteria()) { }

        #endregion

        #region Métodos

        /// <summary>
        /// Realiza um pedido para um cliente na cafeteria.
        /// </summary>
        /// <param name="idCliente">ID do cliente.</param>
        /// <param name="ids">IDs dos produtos do pedido.</param>
        /// <exception cref="ArgumentException">Lançada quando o ID do cliente ou IDs dos produtos são inválidos.</exception>
        /// <exception cref="Exception">Lançada quando o cliente não é encontrado ou nenhum produto válido é adicionado ao pedido.</exception>
        public override void FazerPedido(string idCliente, string ids)
        {
            idCliente = idCliente.Trim();

            if (string.IsNullOrWhiteSpace(idCliente) || !int.TryParse(idCliente, out int numId))
            {
                throw new ArgumentException("ID de cliente inválido.");
            }

            Cliente cliente = LocalizarClientePorId(numId);
            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado.");
            }

            ids = ids.Trim();
            if (string.IsNullOrWhiteSpace(ids))
            {
                throw new ArgumentException("IDs de produtos inválidos.");
            }

            List<int> idsProdutos = new List<int>();
            foreach (var id in ids.Split(','))
            {
                if (int.TryParse(id.Trim(), out int parsedId))
                {
                    idsProdutos.Add(parsedId);
                }
                else
                {
                    throw new ArgumentException($"ID de produto inválido: {id.Trim()}");
                }
            }

            List<Produto> produtosAdicionados = Cardapio.GerarPedido(idsProdutos, new List<Produto>());

            if (produtosAdicionados.Count > 0)
            {
                double total = 0;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Pedido realizado:");
                foreach (var produto in produtosAdicionados)
                {
                    sb.AppendLine($"{produto.ToString()}");
                    total += produto.Valor;
                }
                sb.AppendLine();
                sb.AppendLine($"Valor Total: R$ {total:F2}");
                Console.WriteLine(sb.ToString());
            }
            else
            {
                throw new Exception("Nenhum produto válido foi adicionado ao pedido.");
            }
        }

        #endregion
    }
}