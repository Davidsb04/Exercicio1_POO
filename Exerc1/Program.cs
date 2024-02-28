using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace Exerc1
{
    internal class Program
    {
        static int opcao = 0;
        static List<Conta> contas = new List<Conta>();

        static void Main(string[] args)
        {           
            MenuInicial();
        }  
        static void MenuInicial()
        {
            do
            {
                opcao = ObterEntrada<int>("[1] Criar conta \n[2] Acessar conta \n[3] Sair \n\nEscolha uma opção: ");

                switch (opcao)
                {
                    case 1:
                        AdicionarConta();
                        break;
                    case 2:
                        OperacoesDaConta();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.");
                        break;
                }
            }while(opcao != 3);
        }
        static void AdicionarConta()
        {
            string cpf = "";
            do
            {
                cpf = ObterEntrada<string>("Informe seu CPF (11 dígitos): ");
            } while (cpf.Length != 11);

            Random random = new Random();
            string identificador = random.Next(10000, 100000).ToString();
            Console.WriteLine("\nO identificador da sua conta é: " + identificador);

            contas.Add(new Conta(cpf, identificador));
        }
        static void OperacoesDaConta()
        {
            string entrada = ObterEntrada<string>("Informe o identificador ou CPF: ");
            Conta obterConta = contas.Find(c => c.identificador == entrada || c.CPF == entrada);

            if (obterConta != null)
            {
                do
                {
                    opcao = ObterEntrada<int>("[1] Depositar valor \n[2] Sacar valor \n[3] Exibir dados da conta \n[4] Exibir extrato \n[5] Sair \n\nEscolha uma opção: ");

                    switch (opcao)
                    {
                        case 1:
                            obterConta.DepositarValor();
                            break;
                        case 2:
                            obterConta.SacarValor();
                            break;
                        case 3:
                            obterConta.ExibirDadosDaConta();
                            break;
                        case 4:
                            obterConta.ExibirExtrato();
                            break;
                        case 5:
                            break;
                        default:
                            Console.WriteLine("\nOpção inválida!");
                            break;
                    }
                } while (opcao != 5);
            }
            else
            {
                Console.WriteLine("\nConta não encontrada.");
            }
            
        }
        static public T ObterEntrada<T>(string mensagem)
        {
            while (true)
            {
                Console.Write("\n" + mensagem); 
                string entrada = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    try
                    {
                        return (T)Convert.ChangeType(entrada, typeof(T));
                    }
                    catch (FormatException) 
                    {
                        Console.WriteLine("\nInsira um valor válido.");
                    }                    
                }
                else
                {
                    Console.WriteLine("\nNão é permitido valores vazios. Tente novamente!");
                }
            }
        }
    }    
}