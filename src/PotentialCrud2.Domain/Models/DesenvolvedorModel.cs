using System;

namespace PotentialCrud2.Domain.Models
{
    public class DesenvolvedorModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private char _sexo;
        public char Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        private int _idade;
        public int Idade
        {
            get { return _idade; }
            set { _idade = value; }
        }

        private string _hobby;
        public string Hobby
        {
            get { return _hobby; }
            set { _hobby = value; }
        }

        private DateTime _dataNascimento;
        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; }
        }

        private DateTime _dataHoraInclusao;
        public DateTime DataHoraInclusao
        {
            get { return _dataHoraInclusao; }
            set { _dataHoraInclusao = value == null ? DateTime.UtcNow : value; }
        }

        private DateTime _dataHoraAlteracao;
        public DateTime DataHoraAlteracao
        {
            get { return _dataHoraAlteracao; }
            set { _dataHoraAlteracao = value; }
        }
    }
}
