using System;

namespace PotentialCrud2.Domain.Dtos.Desenvolvedor
{
    public class DesenvolvedorDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public int Idade { get; set; }
        public string Hobby { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataHoraAlteracao { get; set; }
    }
}
