using System;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Banco");

            ContaBancaria conta1 = new ContaBancaria();

            conta1.saldo = 1000;
            conta1.numero = "10";
            conta1.limite = 0;
            conta1.statusEspecial = true;

            conta1.RealizarSaque(200);

            conta1.RealizarDeposito(300);

            conta1.RealizarDeposito(500);

            conta1.RealizarSaque(200);

            ContaBancaria conta2 = new ContaBancaria();

            conta2.saldo = 300;
            conta2.numero = "20";
            conta2.limite = 0;
            conta2.statusEspecial = true;

            conta2.RealizarSaque(100);
            conta2.RealizarDeposito(500);

            conta1.RealizarTransferencia(conta2, 400, ref conta2.indexMovimentacaoBanco);

            conta1.EmitirSaldo();
            conta1.ExibirExtrato();

            Console.WriteLine();

            conta2.EmitirSaldo();
            conta2.ExibirExtrato();
        }
    }
}
