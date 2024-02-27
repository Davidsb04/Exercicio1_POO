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
            Console.Write("\nInforme seu CPF: ");
            string cpf = Console.ReadLine();

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
                Console.Write("\n[1] Depositar valor \n[2] Sacar valor \n[3] Exibir saldo \n[4] Exibir extrato \n[5] Sair \n\nEscolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        conta.DepositarValor();
                        break;
                    case 2:
                        conta.SacarValor();
                        break;
                    case 3:
                        conta.ExibirSaldo();
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
    }    
}