using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class ContaBancaria
    {
        public string numero;
        public double saldo;
        public bool statusEspecial;
        public double limite;
        public Movimentacao[] movimentacaoBanco;
        public int indexMovimentacaoBanco = 0;

        public void RealizarSaque(double valor)
        {
            if (valor < saldo + limite)
            {
                saldo -= valor;
                Movimentacao movimentacao = new Movimentacao();
                movimentacao.valorMovimentado = valor;
                movimentacao.tipoMovimento = TipoMovimentacao.Debito;
                movimentacao.tipoOperacao = TipoMovimentacao.Saque;
                movimentacaoBanco[indexMovimentacaoBanco] = movimentacao;
                indexMovimentacaoBanco++;
            }
            else
                Console.WriteLine("Operação inválida, saldo indisponível");
        }

        public void RealizarDeposito(double valor)
        {
            saldo += valor;
            Movimentacao movimentacao = new Movimentacao();
            movimentacao.valorMovimentado = valor;
            movimentacao.tipoMovimento = TipoMovimentacao.Debito;
            movimentacao.tipoOperacao = TipoMovimentacao.Deposito;
            movimentacaoBanco[indexMovimentacaoBanco] = movimentacao;
            indexMovimentacaoBanco++;
        }

        public void EmitirSaldo()
        {
            Console.WriteLine($"O saldo atual da conta Nº{numero} é de: {saldo}");
        }

        public void ExibirExtrato()
        {
            Console.WriteLine($"Extrato de suas ultimas movimentações (limite 10): ");
            for (int i = 0; i < movimentacaoBanco.Length; i++)
            {
                if (movimentacaoBanco[i] != null)
                {
                    if (movimentacaoBanco[i].tipoMovimento != TipoMovimentacao.Transferencia)
                        Console.WriteLine($"{i + 1} - Valor de {movimentacaoBanco[i].valorMovimentado} {movimentacaoBanco[i].tipoMovimento} via {movimentacaoBanco[i].tipoOperacao}");
                    else
                        Console.WriteLine($"{i + 1} - Valor de {movimentacaoBanco[i].valorMovimentado} {movimentacaoBanco[i].tipoOperacao} via {movimentacaoBanco[i].tipoMovimento}");
                }
            }
        }

        public void RealizarTransferencia(ContaBancaria conta, double valor, ref int indexMovimentacaoReceptor)
        {
            saldo -= valor;
            conta.saldo += valor;
            //conta.movimentacaoBanco[indexMovimentacaoReceptor].valorMovimentado = valor;
            //conta.movimentacaoBanco[indexMovimentacaoReceptor].tipoMovimento = TipoMovimentacao.Transferencia;
            //conta.movimentacaoBanco[indexMovimentacaoReceptor].tipoOperacao = TipoMovimentacao.Recebido;
            //indexMovimentacaoReceptor++;

            Movimentacao movimentacao = new Movimentacao();
            movimentacao.valorMovimentado = valor;
            movimentacao.tipoMovimento = TipoMovimentacao.Transferencia;
            movimentacao.tipoOperacao = TipoMovimentacao.Enviado;
            movimentacaoBanco[indexMovimentacaoBanco] = movimentacao;
            indexMovimentacaoBanco++;
        }
    }
}
