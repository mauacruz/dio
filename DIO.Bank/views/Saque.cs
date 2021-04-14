using System;
using System.Collections.Generic;

namespace DIO.Bank {
    public class Saque {
        public bool Sacar(List<Conta> pListaConta){
            bool sair = false;
            string lInput = "";
            int lNumeroConta;
            double lValorSaque;
            Conta lContaSaque;
            do {
                Console.Clear();

                ListaContas.Listar(pListaConta);
                Console.WriteLine("---------------------");
                Console.WriteLine("SAQUE DE VALOR DA CONTA");
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
                        lContaSaque = pListaConta.Find(p => p.Numero == lNumeroConta);
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
                Console.WriteLine (lContaSaque.ToString());
                Console.WriteLine ("Digite o valor de Saque: ");
                lInput = Console.ReadLine();
                if (lInput.ToLower() == "sair"){
                    return false;
                }
                else if (double.TryParse(lInput, out lValorSaque)) {
                    try {
                        lContaSaque.Sacar(lValorSaque);
                        Console.WriteLine("Saque realizado! Tecle <enter> para prosseguir...");    
                        Console.WriteLine(lContaSaque.ToString());
                        Console.ReadLine();
                        sair = true;
                        continue;
                    }
                    catch (SaldoInsuficienteException) {
                        Console.WriteLine("Saldo insuficiente! Tecle <enter> para prosseguir...");    
                        Console.ReadLine();
                        continue;
                    }
                }
            }
            while (!sair);
            return true;
        }            
    }
}