using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegTable
{
    public class Program
    {
        static void Main(string[] args)
        {
            int op = 0;

            while (op != 3)
            {
                Console.WriteLine("Selecione o tipo de estabelecimento:");
                Console.WriteLine("1. Restaurante");
                Console.WriteLine("2. Cafeteria");
                Console.WriteLine("3. Sair");
                Console.Write("Escolha: ");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        MenuRestaurante(new Restaurante());
                        break;
                    case 2:
                        MenuCafeteria(new Cafeteria());
                        break;
                    case 3:
                        op = 3;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void MenuRestaurante(Restaurante restaurante)
        {
            int opcao = 0;

            while (opcao != 8)
            {
                try
                {
                    Console.WriteLine("\nVegTable Restaurante");
                    Console.WriteLine("=====================");

                    Console.WriteLine("\nOBS: Para realizar a reserva faça seu cadastro");
                    Console.WriteLine("=====================");

                    Console.WriteLine("\n1. Mostrar Cardápio");
                    Console.WriteLine("2. Cadastrar Cliente");
                    Console.WriteLine("3. Fazer Reserva");
                    Console.WriteLine("4. Fazer Pedido");
                    Console.WriteLine("5. Finalizar Reserva | Fechar Mesa");
                    Console.WriteLine("6. Ver Lista de Espera");
                    Console.WriteLine("7. Mostrar Clientes nas Mesas");
                    Console.WriteLine("8. Sair");

                    Console.Write("\nEscolha uma opção: ");
                    opcao = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine(restaurante.VerCardapio());
                            break;

                        case 2:
                            Console.Write("Nome do Cliente: ");
                            string nome = Console.ReadLine().Trim();

                            if (string.IsNullOrWhiteSpace(nome))
                            {
                                Console.WriteLine("Nome inválido.");
                            }
                            else
                            {
                                Cliente novoCliente = restaurante.CadastrarCliente(nome);
                                Console.WriteLine($"Cliente cadastrado com sucesso! {novoCliente.ToString()}");
                            }
                            break;

                        case 3:
                            Console.WriteLine("Nome do cliente:");
                            string nomeReserva = Console.ReadLine().Trim();

                            Console.Write("Número de Pessoas: ");
                            int numPessoas = int.Parse(Console.ReadLine());
                            if (numPessoas > 8)
                            {
                                Console.WriteLine("Esta quantidade pessoas não é valida");
                            }
                            else
                            {
                                Console.WriteLine(restaurante.FazerReserva(nomeReserva, numPessoas));
                            }
                            break;

                        case 4:
                            try
                            {
                                Console.Write("ID da Reserva: ");
                                string idReserva = Console.ReadLine();

                                Reserva reserva = restaurante.ObterReserva(int.Parse(idReserva));
                                if (reserva == null)
                                {
                                    Console.WriteLine("Reserva não encontrada ou pedido já fechado.");
                                    break;
                                }

                                Console.WriteLine(restaurante.VerCardapio());
                                Console.Write("\nIDs dos Produtos (separados por vírgula): ");
                                string ids = Console.ReadLine();

                                restaurante.FazerPedido(idReserva, ids);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 5:
                            Console.Write("ID da Reserva: ");
                            string idReservaStr = Console.ReadLine();

                            Reserva res = restaurante.FinalizarReserva(idReservaStr);
                            Console.WriteLine(res.ToString());
                            break;

                        case 6:
                            Console.WriteLine(restaurante.MostrarListaDeEspera());
                            break;

                        case 7:
                            Console.WriteLine(restaurante.MostrarClientesNasMesas());
                            break;

                        case 8:
                            opcao = 8;
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada de dados inválida. Por favor, tente novamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }

        static void MenuCafeteria(Cafeteria cafeteria)
        {
            int opcao = 0;

            while (opcao != 4)
            {
                try
                {
                    Console.WriteLine("\nVegTable Cafeteria");
                    Console.WriteLine("=====================");

                    Console.WriteLine("\nOBS: Para realizar a compra faça seu cadastro");
                    Console.WriteLine("=====================");

                    Console.WriteLine("\n1. Mostrar Cardápio");
                    Console.WriteLine("2. Cadastrar Cliente");
                    Console.WriteLine("3. Realizar Compra");
                    Console.WriteLine("4. Sair");

                    Console.Write("\nEscolha uma opção: ");
                    opcao = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine(cafeteria.VerCardapio());
                            break;

                        case 2:
                            Console.Write("Nome do Cliente: ");
                            string nome = Console.ReadLine().Trim();

                            if (string.IsNullOrWhiteSpace(nome))
                            {
                                Console.WriteLine("Nome inválida.");
                            }
                            else
                            {
                                Cliente novoCliente = cafeteria.CadastrarCliente(nome);
                                Console.WriteLine($"Cliente cadastrado com sucesso! ID: {novoCliente.ToString()}");
                            }
                            break;

                        case 3:
                            try
                            {
                                Console.Write("ID do Cliente: ");
                                string idClienteStr = Console.ReadLine();

                                Cliente cliente = cafeteria.LocalizarClientePorId(int.Parse(idClienteStr));
                                if (cliente == null)
                                {
                                    Console.WriteLine("Cliente não encontrado.");
                                    break;
                                }

                                Console.WriteLine(cafeteria.VerCardapio());
                                Console.Write("\nIDs dos Produtos (separados por vírgula): ");
                                string ids = Console.ReadLine();

                                cafeteria.FazerPedido(idClienteStr, ids);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;

                        case 4:
                            opcao = 4;
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada de dados inválida. Por favor, tente novamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }
        }
    }
}