using System;
using System.Collections.Generic;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;

namespace PotentialCrud2.Service.Test.Desenvolvedor
{
    public class DesenvolvedorTeste
    {
        public static string NomeDesenvolvedor { get; set; }
        public static char SexoDesenvolvedor { get; set; }
        public static int IdadeDesenvolvedor { get; set; }
        public static string HobbyDesenvolvedor { get; set; }
        public static DateTime DataNascimentoDesenvolvedor { get; set; }
        public static string NomeDesenvolvedorAlterado { get; set; }
        public static char SexoDesenvolvedorAlterado { get; set; }
        public static int IdadeDesenvolvedorAlterado { get; set; }
        public static string HobbyDesenvolvedorAlterado { get; set; }
        public static DateTime DataNascimentoDesenvolvedorAlterado { get; set; }
        public static Guid IdDesenvolvedor { get; set; }

        public List<DesenvolvedorDto> listaDesenvolvedorDto = new List<DesenvolvedorDto>();
        public DesenvolvedorDto desenvolvedorDto;
        public DesenvolvedorDtoCreate desenvolvedorDtoCreate;
        public DesenvolvedorDtoCreateResult desenvolvedorDtoCreateResult;
        public DesenvolvedorDtoUpdate desenvolvedorDtoUpdate;
        public DesenvolvedorDtoUpdateResult desenvolvedorDtoUpdateResult;

        public DesenvolvedorTeste()
        {
            IdDesenvolvedor = Guid.NewGuid();
            NomeDesenvolvedor = Faker.Name.FullName();
            SexoDesenvolvedor = 'M';
            IdadeDesenvolvedor = 25;
            HobbyDesenvolvedor = "Limpar a casa";
            DataNascimentoDesenvolvedor = Faker.DateOfBirth.Next();

            NomeDesenvolvedorAlterado = Faker.Name.FullName();
            SexoDesenvolvedorAlterado = 'F';
            IdadeDesenvolvedorAlterado = 26;
            HobbyDesenvolvedorAlterado = "Trabalhar";
            DataNascimentoDesenvolvedorAlterado = Faker.DateOfBirth.Next();

            for (int i = 0; i < 10; i++)
            {
                var dto = new DesenvolvedorDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Sexo = 'M',
                    Idade = 25,
                    Hobby = "Pescar no mato",
                    DataNascimento = Faker.DateOfBirth.Next()
                };

                listaDesenvolvedorDto.Add(dto);
            }

            desenvolvedorDto = new DesenvolvedorDto
            {
                Id = IdDesenvolvedor,
                Nome = NomeDesenvolvedor,
                Sexo = SexoDesenvolvedor,
                Idade = IdadeDesenvolvedor,
                Hobby = HobbyDesenvolvedor,
                DataNascimento = DataNascimentoDesenvolvedor
            };

            desenvolvedorDtoCreate = new DesenvolvedorDtoCreate
            {
                Nome = NomeDesenvolvedor,
                Sexo = SexoDesenvolvedor,
                Idade = IdadeDesenvolvedor,
                Hobby = HobbyDesenvolvedor,
                DataNascimento = DataNascimentoDesenvolvedor
            };

            desenvolvedorDtoCreateResult = new DesenvolvedorDtoCreateResult
            {
                Id = IdDesenvolvedor,
                Nome = NomeDesenvolvedor,
                Sexo = SexoDesenvolvedor,
                Idade = IdadeDesenvolvedor,
                Hobby = HobbyDesenvolvedor,
                DataNascimento = DataNascimentoDesenvolvedor,
                DataHoraInclusao = DateTime.UtcNow
            };

            desenvolvedorDtoUpdate = new DesenvolvedorDtoUpdate
            {
                Id = IdDesenvolvedor,
                Nome = NomeDesenvolvedorAlterado,
                Sexo = SexoDesenvolvedorAlterado,
                Idade = IdadeDesenvolvedorAlterado,
                Hobby = HobbyDesenvolvedorAlterado,
                DataNascimento = DataNascimentoDesenvolvedorAlterado
            };

            desenvolvedorDtoUpdateResult = new DesenvolvedorDtoUpdateResult
            {
                Id = IdDesenvolvedor,
                Nome = NomeDesenvolvedorAlterado,
                Sexo = SexoDesenvolvedorAlterado,
                Idade = IdadeDesenvolvedorAlterado,
                Hobby = HobbyDesenvolvedorAlterado,
                DataNascimento = DataNascimentoDesenvolvedorAlterado,
                DataHoraAlteracao = DateTime.UtcNow
            };
        }
    }
}
