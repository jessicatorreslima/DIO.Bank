using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private double CreditoDisponivel { get; set; }
        private string Nome { get; set; }
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {            
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.CreditoDisponivel = credito;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.CreditoDisponivel *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            if (this.Saldo < 0)
            {
                this.CreditoDisponivel += this.Saldo;
            }

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            if (valorDeposito > 0)
            {
                this.Saldo += valorDeposito;
                Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            }
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo da conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}