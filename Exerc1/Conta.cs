using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exerc1
{
    internal class Conta
    {
        private Stack<string> extrato = new Stack<string>(10);
        private double saldo;
        private int identificador;
        private string CPF;

        public Conta(string cpf, int identificador)
        {
            saldo = 0;
            CPF = cpf;
            this.identificador = identificador;
        }

        public void DepositarValor()
        {
            Console.Write("\nDigite o valor que deseja depositar: R$");
            double valor = double.Parse(Console.ReadLine());

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
            Console.Write("\nDigite o valor que deseja sacar: R$");
            double valor = double.Parse(Console.ReadLine());

            double max_Saque = saldo + 100;

            if(valor > max_Saque)
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
        public void ExibirSaldo()
        {
            if(saldo > 0)
            {
                Console.WriteLine($"\nO saldo positivo da conta é R${saldo}");
            }
            else
            {
                Console.WriteLine($"\nO saldo negativo da conta é R${saldo}");
            }
        }
        public double CalcularTaxaDeDeposito(double valor)
        {
            double taxa = saldo * 0.03;

            return valor += taxa;
        }
        
        public void ExibirExtrato()
        {
            if(extrato.Count == 0)
            {
                Console.WriteLine("\nNão foram feitas transações na conta.");
            }
            else
            {
                string elementoDoExtrato = extrato.Pop();
                Console.WriteLine(elementoDoExtrato);
            }
        }
    }
}
