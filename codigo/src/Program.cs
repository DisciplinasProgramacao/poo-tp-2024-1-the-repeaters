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
            while (true)
            {
                Estabelecimento estabelecimento = SelecionarEstabelecimento();

                if (estabelecimento is Restaurante restaurante)
                {
                    MenuRestaurante(restaurante);
                }
                else if (estabelecimento is Cafeteria cafeteria)
                {
                    MenuCafeteria(cafeteria);
                }
                if (estabelecimento == null)
                {
                    break;
                }
            }
        }

        static Estabelecimento SelecionarEstabelecimento()
        {
            while (true)
            {
                Console.WriteLine("Selecione o tipo de estabelecimento:");
                Console.WriteLine("1. Restaurante");
                Console.WriteLine("2. Cafeteria");
                Console.WriteLine("3. Sair");
                Console.Write("Escolha: ");
                string tipo = Console.ReadLine();

                switch (tipo)
                {
                    case "1":
                        return new Restaurante();
                    case "2":
                        return new Cafeteria();
                    case "3":
                        return null;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void MenuRestaurante(Restaurante restaurante)
        {
            while (true)
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
                    string opcao = Console.ReadLine();

                    Console.Clear();

                    switch (opcao)
                    {
                        case "1":
                            Console.WriteLine(restaurante.VerCardapio());
                            break;

                        case "2":
                            Console.Write("Nome do Cliente: ");
                            string nome = Console.ReadLine().Trim();

                            if (string.IsNullOrWhiteSpace(nome))
                            {
                                Console.WriteLine("Nome inválido.");
                            }
                            else
                            {
                                Cliente novoCliente = restaurante.CadastrarCliente(nome);
                                Console.WriteLine($"Cliente cadastrado com sucesso! ID: {novoCliente.IdCliente}, Nome: {novoCliente.Nome}");
                            }
                            break;

                        case "3":
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

                        case "4":
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

                        case "5":
                            Console.Write("ID da Reserva: ");
                            string idReservaStr = Console.ReadLine();
                            Console.Write("Quantas pessoas deseja dividir a conta? ");
                            int numPessoasFinalizar = int.Parse(Console.ReadLine());
                            restaurante.FinalizarReserva(idReservaStr, numPessoasFinalizar);
                            break;

                        case "6":
                            Console.WriteLine(restaurante.MostrarListaDeEspera());
                            break;

                        case "7":
                            Console.WriteLine(restaurante.MostrarClientesNasMesas());
                            break;

                        case "8":
                            return;

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
            while (true)
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
                    string opcao = Console.ReadLine();

                    Console.Clear();

                    switch (opcao)
                    {
                        case "1":
                            Console.WriteLine(cafeteria.VerCardapio());
                            break;

                        case "2":
                            Console.Write("Nome do Cliente: ");
                            string nome = Console.ReadLine().Trim();

                            if (string.IsNullOrWhiteSpace(nome))
                            {
                                Console.WriteLine("Nome inválido.");
                            }
                            else
                            {
                                Cliente novoCliente = cafeteria.CadastrarCliente(nome);
                                Console.WriteLine($"Cliente cadastrado com sucesso! ID: {novoCliente.IdCliente}, Nome: {novoCliente.Nome}");
                            }
                            break;

                        case "3":
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

                        case "4":
                            return;

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

