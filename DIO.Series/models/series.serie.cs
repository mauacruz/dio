namespace DIO.Series
{
    using System;

    class Serie: Base, ISerie {
        private ISerieRepository _repositorio;
        private Genero _genero;
        private string _titulo;
        private string _descricao;
        private int _ano;

        public Serie(ISerieRepository pRepositorio){
            this._repositorio = pRepositorio;
        }

        public ISerie Genero (Genero value){
            this._genero = value;
            return this;            
        }

        public ISerie Titulo (string value){
            this._titulo = value;
            return this;
        }

        public ISerie Descricao (string value){
            this._descricao = value;
            return this;
        }

        public ISerie Ano (int value){
            this._ano = value;
            return this;
        }

        public override string ToString(){
            string retorno = "";
            retorno += "Gênero: " + this._genero + Environment.NewLine;
            retorno += "Título: " + this._titulo + Environment.NewLine;
            retorno += "Descrição: " + this._descricao + Environment.NewLine;
            retorno += "Ano de início: " + this._ano;
            return retorno;
        }

        public bool Save (){
            _repositorio.Save(this);
            return true;
        }


    }
}