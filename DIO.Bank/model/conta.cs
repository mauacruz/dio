namespace DIO.Bank
{
    public class Conta
    {
        private int Numero { get; set; }
        private string Nome  { get; set; }
        private double Credito { get; set; }
        private double Saldo { get; set; }
        private TipoConta TipoConta { get; set; }

        private string TipoContaToString () {
            switch (this.TipoConta) {
                case TipoConta.PessoaFisica : return "Pessoa Física";
                case TipoConta.PessoaJuridica : return "Pessoa Jurídica";
                default : return "Unknown";
            }
        }
        public Conta (int pNumero, string pNome, double pCredito, double pSaldo, TipoConta pTipoConta) {
            this.Numero = pNumero;
            this.Nome = pNome;
            this.Credito = pCredito;
            this.Saldo = pSaldo;
            this.TipoConta = pTipoConta;
        } 


        public override string ToString() {
            
            return string.Format("# {0} ", this.Numero) +
                string.Format("| Tipo de Conta: {s} ", this.TipoContaToString()) +
                string.Format("| Nome: {s} ", this.Nome) +
                string.Format("| Crédito: {0:0,0.0} ", this.Credito) + 
                string.Format("| Saldo: {0:0,0.0} ", this.Saldo);  
        }

    }
}