using System;
using System.Collections.Generic;

namespace DIO.Bank {
    public static class ListaContas {
        public static void Listar (List<Conta> pListaConta){
            Console.Clear();
            Console.WriteLine("Relação de Contas Cadastradas");
            Console.WriteLine("---------------------");

            if (pListaConta.Count <= 0){
                Console.WriteLine("Nenhuma conta cadastrada ainda!");
            }
            else {
                foreach (Conta lConta in pListaConta){
                    Console.WriteLine(lConta.ToString());
                }
            }
            Console.WriteLine("---------------------");

        }
    }
}
