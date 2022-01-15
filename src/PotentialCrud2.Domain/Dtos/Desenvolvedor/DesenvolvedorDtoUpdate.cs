using System;
using System.ComponentModel.DataAnnotations;

namespace PotentialCrud2.Domain.Dtos.Desenvolvedor
{
    public class DesenvolvedorDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve possuir máximo de {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sexo é obrigatório")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "Idade é obrigatório")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Hobby é obrigatório")]
        public string Hobby { get; set; }

        [Required(ErrorMessage = "Data nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }
    }
}
