using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            /*Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Jéssica Torres");
            Console.WriteLine(minhaConta.ToString());*/

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper().Trim() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CadastrarConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigada por utilizar nossos serviços!");
            Console.ReadLine();
        }

        private static void ListarContas()
        {
            Console.WriteLine("\n-----------------");
            Console.WriteLine("| Listar contas |");
            Console.WriteLine("-----------------\n");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas! Escolha a opção 2 no menu principal para cadastrar uma nova conta :)");
                return;
            }

            for (int i=0; i<listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);

            }
        }

        private static void CadastrarConta()
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine("| Cadastrar Nova Conta |");
            Console.WriteLine("---------------------\n");

            Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            
            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito da conta: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static void Transferir()
        {
            Console.WriteLine("\n--------------");
            Console.WriteLine("| Transferir |");
            Console.WriteLine("--------------\n");

            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());   

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine("\n---------");
            Console.WriteLine("| Sacar |");
            Console.WriteLine("---------\n");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("\n-------------");
            Console.WriteLine("| Depositar |");
            Console.WriteLine("-------------\n");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\n--------------------------");
            Console.WriteLine("| Bem-vinde ao DIO Bank! |");
            Console.WriteLine("--------------------------\n");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Cadastrar nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair\n");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
