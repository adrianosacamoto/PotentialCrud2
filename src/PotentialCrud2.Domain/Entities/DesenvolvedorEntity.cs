using System;

namespace PotentialCrud2.Domain.Entities
{
    public class DesenvolvedorEntity : BaseEntity
    {
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public int Idade { get; set; }
        public string Hobby { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
