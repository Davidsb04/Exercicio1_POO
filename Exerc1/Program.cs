using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace Exerc1
{
    internal class Program
    {
        static int opcao = 0;

        static void Main(string[] args)
        {
            adicionarConta();
        }

        static void adicionarConta()
        {
            string cpf = "";
            do
            {
                cpf = ObterEntrada<string>("Informe seu CPF (11 dígitos): ");
            } while (cpf.Length != 11);

            Random random = new Random();
            int identificador = random.Next(10000, 100000);
            Console.WriteLine("\nO identificador da sua conta é: " + identificador);

            Conta conta = new Conta(cpf, identificador);

            operacoesDaConta(opcao, conta);
        }
        static void operacoesDaConta(int opcao, Conta conta)
        {
            do
            {
                opcao = ObterEntrada<int>("[1] Depositar valor \n[2] Sacar valor \n[3] Exibir dados da conta \n[4] Exibir extrato \n[5] Sair \n\nEscolha uma opção: ");

                switch (opcao)
                {
                    case 1:
                        conta.DepositarValor();
                        break;
                    case 2:
                        conta.SacarValor();
                        break;
                    case 3:
                        conta.ExibirDadosDaConta();
                        break;
                    case 4:
                        conta.ExibirExtrato();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!");
                        break;
                }
            } while (opcao != 5);
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