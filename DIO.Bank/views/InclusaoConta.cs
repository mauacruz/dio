using System;
using System.Collections.Generic;

namespace DIO.Bank {

    class ContaIncluir {
        private bool[] _preenchido = new bool[4];

        private int _numero; 
        private string _nome;  
        private double _credito; 
        private double _saldo; 
        private TipoConta _tipoConta;

        public int Numero {
            get => _numero; 
        }

        public string Nome {
            get => _nome;
            set {
                _nome = value;
                _preenchido[0] = true;
            }
        }

        public double Credito {
            get => _credito;
            set {
                _credito = value;
                _preenchido[1] = true;
            }
        }

        public double Saldo {
            get => _saldo;
            set {
                _saldo = value;
                _preenchido[2] = true;
            }
        }

        public TipoConta TipoConta { 
            get => _tipoConta;
            set {
                _tipoConta = value;
                _preenchido[3] = true;
            }
        }

        public ContaIncluir(){
            for(int i=0; i < _preenchido.Length; i++){
                _preenchido[i] = false;
            }
            
        }

        public bool Preenchido(string propriedade){
            switch (propriedade.ToLower()){
                case "nome":
                    return _preenchido[0];
                case "credito":
                    return _preenchido[1];
                case "saldo":
                    return _preenchido[2];
                case "tipoconta":
                    return _preenchido[3];
                default:
                    return false;
            }
        }
    }

    public class InclusaoConta {

        public bool IncluirConta(List<Conta> pListaConta){
            Conta lConta;
            
            string lNome = "";
            
            double lSaldo = 0.0;
            short lTipoDigitado = -1;
            bool sair = false;

            TipoConta lTipoConta = TipoConta.PessoaFisica;

            ContaIncluir lContaIncluir = new ContaIncluir();
            string lInput = "";
            double lValorDouble = 0.0;

            do{
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("INCLUSÃO DE CONTA");
                Console.WriteLine("Informe as opções abaixo:");
                Console.WriteLine("---------------------");
                Console.WriteLine("(digite 'sair' + <enter> a qualquer momento para sair)");
                Console.WriteLine("---------------------");
                
                if (! lContaIncluir.Preenchido("nome")) {
                    Console.Write("Nome: ");
                    lInput = Console.ReadLine();
                    if (lInput == "sair"){
                        return false;
                    }
                    lContaIncluir.Nome = lInput;
                }
                else if (! lContaIncluir.Preenchido("credito")) {
                    Console.WriteLine("Nome: " + lContaIncluir.Nome);
                    Console.Write("Credito: ");
                    lInput = Console.ReadLine();
                    if (lInput == "sair"){
                        return false;
                    }

                    if (double.TryParse(lInput, out lValorDouble)) {
                        lContaIncluir.Credito = lValorDouble;
                    }
                }
                else if (! lContaIncluir.Preenchido("saldo")) {
                    Console.WriteLine("Nome: " + lContaIncluir.Nome);
                    Console.WriteLine("Credito: {0:N} ", lContaIncluir.Credito);
                    Console.Write("Saldo: ");
                    lInput = Console.ReadLine();
                    if (lInput == "sair"){
                        return false;
                    }

                    if (double.TryParse(lInput, out lValorDouble)) {
                        lContaIncluir.Saldo = lValorDouble;
                    }

                }
                else if (! lContaIncluir.Preenchido("tipoconta")) {
                    Console.WriteLine("Nome: " + lContaIncluir.Nome);
                    Console.WriteLine("Credito: {0:N}", lContaIncluir.Credito);
                    Console.WriteLine("Saldo: {0:N}", lContaIncluir.Saldo);
                    Console.WriteLine("Selecione o Tipo de Conta: 1 - Física | 2 - Jurídica");
                    lInput = Console.ReadLine();
                    if (lInput == "sair"){
                        return false;
                    }

                    switch(lInput) {
                        case "1": 
                            lContaIncluir.TipoConta = TipoConta.PessoaFisica;
                            break;
                        case "2": 
                            lContaIncluir.TipoConta = TipoConta.PessoaJuridica;
                            break;
                    }
                }
                
                else {
                    Console.WriteLine ("Deseja incluir a conta? (S)im (N)ão ");
                    lInput = Console.ReadLine().ToLower();
                    switch(lInput) {
                        case "s":
                            lConta = new Conta(
                                ObterProximoNumeroConta(pListaConta),
                                lContaIncluir.Nome,
                                lContaIncluir.Credito,
                                lContaIncluir.Saldo,
                                lContaIncluir.TipoConta
                            );
                            pListaConta.Add(lConta);
                            sair = true;
                            break;
                        case "n": 
                            sair = true;
                            break;
                        default: break;
                    }
                }
                
            } while (!sair);
            return true;

        }

        public int ObterProximoNumeroConta (List<Conta> pListaConta){
            if (pListaConta.Count <= 0) {
                return 1;
            }
            else {
                int numero = 0;
                foreach (Conta lConta in pListaConta)
                {
                    if (numero < lConta.Numero){
                        numero = lConta.Numero;
                    }

                }
                return ++numero;
            }    
        }

    }
}