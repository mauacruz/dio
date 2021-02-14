using System;

namespace DIO.Bank {
    class Program {
        static void Main(string[] args) {
            string lTecla;
            string lMensagem = "";
            do {
                DesenhaMenu(lMensagem);
                lTecla = Console.ReadLine().ToUpper();
                if (!ValidarTecla(lTecla)){
                    lMensagem = "Tecla inválida";
                }
                else {
                    lMensagem = "";
                }
            }
            while (lTecla != "X");
        }

        static void DesenhaMenu(string pMensagem) {
            Console.Clear();
            Console.WriteLine("Menu Principal");
            Console.WriteLine("---------------------");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("X - Sair");

            if (!pMensagem.Equals("")) {
                Console.WriteLine("---------------------");
                Console.WriteLine(pMensagem);
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
    }
}
