using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Program
    { 
        static void Main(string[] args)
        {
            Restaurante restaurante = new Restaurante();

            while (true)
            {
                
                Console.WriteLine("\nVegTable");
                Console.WriteLine("=====================");

                Console.WriteLine("1. Mostrar Cardápio");
                Console.WriteLine("2. Fazer Reserva");
                Console.WriteLine("3. Fazer Pedido");
                Console.WriteLine("4. Finalizar Reserva | Fechar Mesa");
                Console.WriteLine("5. Verificar Status da Mesa");
                Console.WriteLine("6. Ver Lista de Espera");
                Console.WriteLine("7. Verificar Pedidos da Mesa");
                Console.WriteLine("8. Cancelar Reserva");
                Console.WriteLine("9. Editar Pedido");
                Console.WriteLine("10. Sair");

                Console.Write("\nEscolha uma opção: ");
                string opcao = Console.ReadLine();

                Console.Clear();

                if (opcao == null)
                {
                    Console.WriteLine("Opção inválida.");
                    continue;
                }

                switch (opcao)
                {
                    case "1":
                        restaurante.VerCardapio();
                        break;

                    case "2":
                        Console.Write("Nome do Cliente: ");
                        string nome = Console.ReadLine();
                        if (nome == null)
                        {
                            Console.WriteLine("Nome inválido.");
                            break;
                        }

                        Console.Write("Número de Pessoas: ");
                        string numPessoasStr = Console.ReadLine();
                        if (numPessoasStr == null || !int.TryParse(numPessoasStr, out int numPessoas))
                        {
                            Console.WriteLine("Número de pessoas inválido.");
                            break;
                        }

                        Cliente cliente = new Cliente(nome);
                        restaurante.AlocarMesa(cliente, numPessoas);
                        break;

                    case "3":
                        Console.Write("ID da Reserva: ");
                        string idReservaStr = Console.ReadLine();
                        if (idReservaStr == null || !int.TryParse(idReservaStr, out int idReservaPedido))
                        {
                            Console.WriteLine("ID de reserva inválido.");
                            break;
                        }

                        Reserva reserva = restaurante.ObterReserva(idReservaPedido);
                        if (reserva != null && reserva.Pedido != null)
                        {
                            restaurante.VerCardapio();
                            
                            Console.Write("\nIDs dos Produtos (separados por vírgula): ");
                            string ids = Console.ReadLine();
                            if (ids == null)
                            {
                                Console.WriteLine("IDs de produtos inválidos.");
                                break;
                            }

                            List<int> idsProdutos = new List<int>(Array.ConvertAll(ids.Split(','), int.Parse));
                            List<Produto> produtosAdicionados = restaurante.IncluirProduto(idReservaPedido, idsProdutos);

                            Console.WriteLine("Produtos adicionados ao pedido:");
                            foreach (var produto in produtosAdicionados)
                            {
                                Console.WriteLine($"- {produto.Nome}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Reserva não encontrada ou pedido já fechado.");
                        }
                        break;

                    case "4":
                        Console.Write("ID da Reserva: ");
                        idReservaStr = Console.ReadLine();
                        if (idReservaStr == null || !int.TryParse(idReservaStr, out int idReservaFinalizar))
                        {
                            Console.WriteLine("ID de reserva inválido.");
                            break;
                        }

                        reserva = restaurante.ObterReserva(idReservaFinalizar);
                        if (reserva != null)
                        {
                            Console.Write("Número de Pessoas para Divisão da Conta: ");
                            string numPessoasStrFinalizar = Console.ReadLine();
                            if (numPessoasStrFinalizar == null || !int.TryParse(numPessoasStrFinalizar, out int numPessoasFinalizar))
                            {
                                Console.WriteLine("Número de pessoas inválido.");
                                break;
                            }

                            reserva.Pedido.FecharPedido(numPessoasFinalizar);
                            restaurante.FinalizarReserva(idReservaFinalizar, DateTime.Now);
                        }
                        else
                        {
                            Console.WriteLine("Reserva não encontrada.");
                        }
                        break;

                    case "5":
                        Console.Write("ID da Mesa: ");
                        string idMesaStr = Console.ReadLine();
                        if (idMesaStr == null || !int.TryParse(idMesaStr, out int idMesa))
                        {
                            Console.WriteLine("ID de mesa inválido.");
                            break;
                        }

                        Mesa mesa = restaurante.LocalizarMesaPorId(idMesa);
                        if (mesa != null)
                        {
                            string status = mesa.EstahDisponivel() ? "livre" : "ocupada";
                            Console.WriteLine($"Mesa {idMesa} está {status}.");
                        }
                        else
                        {
                            Console.WriteLine("Mesa não encontrada.");
                        }
                        break;

                    case "6":
                        restaurante.MostrarListaDeEspera();
                        break;

                    case "7":
                        Console.Write("ID da Reserva: ");
                        idReservaStr = Console.ReadLine();
                        if (idReservaStr == null || !int.TryParse(idReservaStr, out int idReservaVerificar))
                        {
                            Console.WriteLine("ID de reserva inválido.");
                            break;
                        }

                        reserva = restaurante.ObterReserva(idReservaVerificar);
                        if (reserva != null)
                        {
                            Console.WriteLine("Itens no pedido:");
                            reserva.Pedido.Relatorio(idReservaVerificar);
                        }
                        else
                        {
                            Console.WriteLine("Reserva não encontrada.");
                        }
                        break;

                    case "8":
                        Console.Write("ID da Reserva: ");
                        idReservaStr = Console.ReadLine();
                        if (idReservaStr == null || !int.TryParse(idReservaStr, out int idReservaCancelar))
                        {
                            Console.WriteLine("ID de reserva inválido.");
                            break;
                        }

                        restaurante.CancelarReserva(idReservaCancelar);
                        break;

                    case "9":
                        Console.Write("ID da Reserva: ");
                        idReservaStr = Console.ReadLine();
                        if (idReservaStr == null || !int.TryParse(idReservaStr, out int idReservaEditar))
                        {
                            Console.WriteLine("ID de reserva inválido.");
                            break;
                        }

                        reserva = restaurante.ObterReserva(idReservaEditar);
                        if (reserva != null && reserva.Pedido != null)
                        {
                            Console.Write("Adicionar (A) ou Remover (R) itens? ");
                            string acao = Console.ReadLine()?.ToUpper();
                            if (acao == "A")
                            {
                                Console.Write("IDs dos Produtos para adicionar (separados por vírgula): ");
                                string idsAdicionar = Console.ReadLine();
                                if (idsAdicionar == null)
                                {
                                    Console.WriteLine("IDs de produtos inválidos.");
                                    break;
                                }

                                List<int> idsProdutosAdicionar = new List<int>(Array.ConvertAll(idsAdicionar.Split(','), int.Parse));
                                List<Produto> produtosAdicionados = restaurante.IncluirProduto(idReservaEditar, idsProdutosAdicionar);

                                Console.WriteLine("Produtos adicionados ao pedido:");
                                foreach (var produto in produtosAdicionados)
                                {
                                    Console.WriteLine($"- {produto.Nome}");
                                }
                            }
                            else if (acao == "R")
                            {
                                Console.Write("IDs dos Produtos para remover (separados por vírgula): ");
                                string idsRemover = Console.ReadLine();
                                if (idsRemover == null)
                                {
                                    Console.WriteLine("IDs de produtos inválidos.");
                                    break;
                                }

                                List<int> idsProdutosRemover = new List<int>(Array.ConvertAll(idsRemover.Split(','), int.Parse));
                                foreach (int id in idsProdutosRemover)
                                {
                                    Produto produto = reserva.Pedido.Itens.Find(p => p.Id == id);
                                    if (produto != null)
                                    {
                                        reserva.Pedido.Itens.Remove(produto);
                                    }
                                }

                                Console.WriteLine("Produtos removidos do pedido.");
                            }
                            else
                            {
                                Console.WriteLine("Ação inválida.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Reserva não encontrada ou pedido já fechado.");
                        }
                        break;

                    case "10":
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}



