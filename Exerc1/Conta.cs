using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exerc1
{
    internal class Conta
    {
        private Stack<string> extrato = new Stack<string>();
        private double saldo;
        public string identificador { get; private set; }
        public string CPF { get; private set; }

        public Conta(string cpf, string identificador)
        {
            saldo = 0;
            CPF = cpf;
            this.identificador = identificador;
        }

        public void DepositarValor()
        {
            double valor = Program.ObterEntrada<double>("\nDigite o valor que deseja depositar: R$");

            if (saldo < 0)
            {
                saldo += CalcularTaxaDeDeposito(valor);
                Console.WriteLine("\nDeposito com taxa de 3% realizado com sucesso!");
                extrato.Push($"Deposito: R${valor}");
            }
            else
            {
                saldo += valor;
                Console.WriteLine("\nDeposito realizado com sucesso!");
                extrato.Push($"Deposito: R${valor}");
            }
        }
        public void SacarValor()
        {
            double valor = Program.ObterEntrada<double>("\nDigite o valor que deseja sacar: R$");

            double max_Saque = saldo + 100;

            if (valor > max_Saque)
            {
                Console.WriteLine("\nEsse valor ultrapassa o limite para o saque!");
            }
            else
            {
                saldo -= valor;
                Console.WriteLine("\nSaque realizado com sucesso!");
                extrato.Push($"Saque: R${valor}");
            }
        }
        public void ExibirDadosDaConta()
        {
            if (saldo >= 0)
            {
                Console.WriteLine($"\nCPF: {CPF}\nIdentificador: {identificador}\nO saldo positivo da conta é R${saldo}");
            }
            else
            {
                Console.WriteLine($"\nCPF: {CPF}\nIdentificador: {identificador}\nO saldo negativo da conta é R${saldo}");
            }
        }
        public double CalcularTaxaDeDeposito(double valor)
        {
            double taxa = saldo * 0.03;

            return valor += taxa;
        }
        
        public void ExibirExtrato()
        {
            string[] extratoClonado = extrato.ToArray();

            if (extrato.Count == 0)
            {
                Console.WriteLine("\nNão foram feitas transações na conta.");
            }
            else
            {
                string ultimoElementoDoExtrato = extrato.Peek();
                Console.WriteLine("\nA última movimentação feita foi " + ultimoElementoDoExtrato);

                Console.WriteLine("\nAs 10 últimas movimentações da conta são:");
                for (int i = 0; i < extratoClonado.Length && i < 10; i++)
                {
                    Console.WriteLine(extratoClonado[i]);
                }
            }            
        }        
    }
}
