using System;
using System.Collections.Generic;

namespace DIO.Bank {
    public class Deposito {
        public bool Depositar(List<Conta> pListaConta){
            bool sair = false;
            string lInput = "";
            int lNumeroConta;
            double lValorDeposito;
            Conta lContaDeposito;
            do {
                Console.Clear();

                
                Console.WriteLine("---------------------");
                Console.WriteLine("DEPÓSITO DE VALOR NA CONTA");
                Console.WriteLine("---------------------");
                Console.WriteLine("(digite 'sair' + <enter> a qualquer momento para sair)");
                Console.WriteLine("---------------------");
                ListaContas.Listar(pListaConta);
                
                Console.Write("Digite o número da conta: ");
                lInput = Console.ReadLine();
                if (lInput.ToLower() == "sair"){
                    sair = true;
                    continue;
                }
                else if (Int32.TryParse(lInput, out lNumeroConta)) {
                    if (pListaConta.Exists(p => p.Numero == lNumeroConta)) {
                        lContaDeposito = pListaConta.Find(p => p.Numero == lNumeroConta);
                    }
                    else {
                        Console.WriteLine("Número de Conta não encontrado! Tecle <enter> para prosseguir...");    
                        Console.ReadLine();
                        continue;
                    }
                }
                else {
                    Console.WriteLine("Valor inválido para Número de Conta! Tecle <enter> para prosseguir...");    
                    Console.ReadLine();
                    continue;
                }
                Console.WriteLine (lContaDeposito.ToString());
                Console.WriteLine ("Digite o valor do depósito: ");
                lInput = Console.ReadLine();
                if (lInput.ToLower() == "sair"){
                    return false;
                }
                else if (double.TryParse(lInput, out lValorDeposito)) {
                    lContaDeposito.Depositar(lValorDeposito);
                    Console.WriteLine("Depósito realizado! Tecle <enter> para prosseguir...");    
                    Console.WriteLine(lContaDeposito.ToString());
                    Console.ReadLine();
                    sair = true;
                    continue;
                }
            }
            while (!sair);
            return true;
        }            
    }
}