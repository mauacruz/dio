namespace DIO.Bank
{
    public class Conta
    {
        private int _numero { get; set; }
        private string _nome  { get; set; }
        private double _credito { get; set; }
        private double _saldo { get; set; }
        private TipoConta _tipoConta { get; set; }

        private string TipoContaToString () {
            switch (this._tipoConta) {
                case TipoConta.PessoaFisica : return "Pessoa Física";
                case TipoConta.PessoaJuridica : return "Pessoa Jurídica";
                default : return "Unknown";
            }
        }
        public Conta (int pNumero, string pNome, double pCredito, double pSaldo, TipoConta pTipoConta) {
            this._numero = pNumero;
            this._nome = pNome;
            this._credito = pCredito;
            this._saldo = pSaldo;
            this._tipoConta = pTipoConta;
        } 

        public int Numero { get{return _numero;} }

        public override string ToString() {
            string lRetorno = string.Format("# {0} ", this._numero);
            lRetorno += string.Format("| Tipo de Conta: " + this.TipoContaToString());
            lRetorno += string.Format(" | Nome: " + this._nome);
            lRetorno += string.Format(" | Crédito: {0:0,0.0} ", this._credito);
            lRetorno += string.Format(" | Saldo: {0:0,0.0} ", this._saldo);
            return lRetorno;
        }

        public bool Sacar (double valorSaque){
            
            // if (this._saldo - valorSaque < (this._credito - 1)){
            //     throw new SaldoInsuficienteException();
            // }

            if ((this._saldo + this._credito) < valorSaque){
                throw new SaldoInsuficienteException();
            }

            this._saldo -= valorSaque;
            return true;
        }

        public void Depositar (double valorDeposito){
            this._saldo += valorDeposito;
        }

        public void Transferir(double valorTransferencia, Conta contaDestino){
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

    }
}
