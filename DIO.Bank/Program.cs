using System;
using System.Collections.Generic;

namespace DIO.Bank {
    class Program {
        static void Main(string[] args) {

            List<Conta> listaContas = new List<Conta>();            
            bool lSaida = false;

            do {
                lSaida = ListarContas(listaContas);
            }
            while (!lSaida);
        }

        static bool ListarContas (List<Conta> pListaConta) {
            string lTecla;
            bool lTeclaValida;

            do {
                ListaContas.Listar(pListaConta);
                Console.WriteLine("1 - Inserir conta | 2 - Transferir | 3 - Sacar | 4 - Depositar | X - Sair");

                lTecla = Console.ReadLine().ToString().ToLower();
                lTeclaValida = ValidarTecla(lTecla);
                if (lTeclaValida) {
                    ChamarViewPelaOpcao(lTecla, pListaConta);
                }
                else {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("Tecla Inválida");
                    Console.ReadLine();
                }
                
            }
            while (lTecla != "x");
            return true;
        }

        static bool ChamarViewPelaOpcao(string pOpcao, List<Conta> pListaConta) {
            switch(pOpcao) {
                case "1" :
                    InclusaoConta incluir = new InclusaoConta();
                    incluir.IncluirConta(pListaConta);
                    return true;
                case "2" : 
                    Transferencia transferir = new Transferencia();
                    transferir.Transferir(pListaConta);
                    return true;
                case "3" : 
                    Saque sacar = new Saque();
                    sacar.Sacar(pListaConta);
                    return true;

                case "4" : 
                    Deposito depositar = new Deposito();
                    depositar.Depositar(pListaConta);
                    return true;
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
                case "x" : return true;
                default : return false;
            }

        }

    }
}
