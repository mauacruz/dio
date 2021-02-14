using System;
using System.Collections.Generic;

namespace DIO.Bank {
    class Program {
        static void Main(string[] args) {

            List<Conta> listaContas = new List<Conta>();            
            bool lSaida = false;
            Console.TreatControlCAsInput = true;

            do {
                lSaida = ListarContas(listaContas);
            }
            while (!lSaida);
        }

        static bool ListarContas (List<Conta> pListaConta) {
            ConsoleKeyInfo lTecla;
            bool lTeclaInvalida;

            Console.WriteLine("Relação de Contas Cadastradas");
            Console.WriteLine("---------------------");

            do {
                if (pListaConta.Count <= 0){
                    Console.WriteLine("Nenhuma conta cadastrada ainda!");
                }
                else {
                    foreach (Conta lConta in pListaConta){
                        Console.WriteLine(lConta.ToString());
                    }
                }
                Console.WriteLine("---------------------");
                Console.WriteLine("1 - Listar contas | 2 - Inserir conta | 3 - Transferir | 4 - Sacar | 5 - Depositar | X - Sair");

                lTecla = Console.ReadKey();
                lTeclaInvalida = ValidarTecla(lTecla.Key.ToString());
                if (lTeclaInvalida) {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Tecla Inválida");
                }
                else {
                    ChamarViewPelaOpcao(lTecla.Key.ToString(), pListaConta);
                }
                
            }
            while (lTecla.Key.ToString() != "X");
            return true;


        }

        static bool ChamarViewPelaOpcao(string pOpcao, List<Conta> pListaConta) {
            switch(pOpcao) {
                case "1" :
                    return true; 
                case "2" :
                    IncluirConta(pListaConta);
                    return true;

                case "3" : return true;
                case "4" : return true;
                case "5" : return true;
                case "6" : return true;
                default : return false;
            }


        }
        static bool ValidarTecla(string pTecla) {
            switch (pTecla) {
                case "1" : return true; 
                case "2" : return true;
                case "3" : return true;
                case "4" : return true;
                case "5" : return true;
                case "6" : return true;
                default : return false;
            }

        }

        static bool IncluirConta(List<Conta> pListaConta){
            string lNome;
            double lCredito;
            double lSaldo;
            int lTipoDigitado;

            TipoConta lTipoConta;

            Console.WriteLine("Nome: ");
            lNome = Console.ReadLine();

            Console.WriteLine("Credito: ");
            try {
                lCredito = Convert.ToDouble(Console.ReadLine());
            }
            catch {
                return false;
            }

            Console.WriteLine("Saldo: ");
            try {
                lSaldo = Convert.ToDouble(Console.ReadLine());
            }
            catch {
                return false;
            }

            Console.WriteLine("Selecione o Tipo de Conta: 1 - Física | 2 - Jurídica");
            try {
                lTipoDigitado = Convert.ToInt16(Console.ReadLine());
                switch(lTipoDigitado) {
                    case 1: 
                        lTipoConta = TipoConta.PessoaFisica;
                        break;
                    case 2: 
                        lTipoConta = TipoConta.PessoaJuridica;
                        break;
                    default : return false;
                }

            }
            catch {
                return false;
            }
            
            return true;


        }
    }
}
