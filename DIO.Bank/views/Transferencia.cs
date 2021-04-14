using System;
using System.Collections.Generic;

namespace DIO.Bank {
    public class Transferencia {
        public bool Transferir(List<Conta> pListaConta){
            Conta lContaOrigem, lContaDestino;
            bool sair = false;
            string lInput = "";
            int lNumeroConta;
            double lValorTransferencia;

            do {
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("TRANSFERÊNCIA DE VALOR ENTRE CONTAS");
                Console.WriteLine("---------------------");
                Console.WriteLine("(digite 'sair' + <enter> a qualquer momento para sair)");
                Console.WriteLine("---------------------");
                ListaContas.Listar(pListaConta);  

                Console.Write("Digite o número da conta origem: ");
                lInput = Console.ReadLine();
                if (lInput.ToLower() == "sair"){
                    sair = true;
                    continue;
                }
                else if (Int32.TryParse(lInput, out lNumeroConta)) {
                    if (pListaConta.Exists(p => p.Numero == lNumeroConta)) {
                        lContaOrigem = pListaConta.Find(p => p.Numero == lNumeroConta);
                    }
                    else {
                        Console.WriteLine("Número de conta não encontrado! Tecle <enter> para prosseguir...");    
                        Console.ReadLine();
                        continue;
                    }
                }
                else {
                    Console.WriteLine("Valor inválido para número de Conta! Tecle <enter> para prosseguir...");    
                    Console.ReadLine();
                    continue;
                }

                Console.Write("Digite o número da conta destino: ");
                lInput = Console.ReadLine();
                if (lInput.ToLower() == "sair"){
                    sair = true;
                    continue;
                }
                else if (Int32.TryParse(lInput, out lNumeroConta)) {
                    if (pListaConta.Exists(p => p.Numero == lNumeroConta)) {
                        lContaDestino = pListaConta.Find(p => p.Numero == lNumeroConta);
                    }
                    else {
                        Console.WriteLine("Número de conta não encontrado! Tecle <enter> para prosseguir...");    
                        Console.ReadLine();
                        continue;
                    }
                }
                else {
                    Console.WriteLine("Valor inválido para número de Conta! Tecle <enter> para prosseguir...");    
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine ("Digite o valor da transferência: ");
                lInput = Console.ReadLine();
                if (lInput.ToLower() == "sair"){
                    return false;
                }
                else if (double.TryParse(lInput, out lValorTransferencia)) {

                    try {
                        lContaOrigem.Transferir(lValorTransferencia, lContaDestino);
                        Console.WriteLine("Transferência realizada! Tecle <enter> para prosseguir...");    
                        Console.WriteLine(lContaOrigem.ToString());
                        Console.WriteLine(lContaDestino.ToString());
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