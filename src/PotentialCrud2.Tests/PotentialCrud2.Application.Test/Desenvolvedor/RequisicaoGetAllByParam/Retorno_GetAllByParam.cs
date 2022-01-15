using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using PotentialCrud2.Application.Controllers;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Application.Test.Desenvolvedor.RequisicaoGetAllByParam
{
    public class Retorno_GetAllByParam
    {
        private DesenvolvedoresController _controller;

        [Fact(DisplayName = "Executar o método GetAllByParamName.")]
        public async Task Invocar_Controller_GetAllByParamName()
        {
            var serviceMock = new Mock<IDesenvolvedorService>();
            var nome = "Fulano";
            var sexo = 'M';
            var idade = 25;
            var hobby = "Dormir";
            var dataNascimento = Faker.DateOfBirth.Next();

            serviceMock.Setup(x => x.GetAllByParamName("Fulano", 0, 1)).ReturnsAsync(
                new List<DesenvolvedorDto>
                {
                    new DesenvolvedorDto{
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    Sexo = sexo,
                    Idade = idade,
                    Hobby = hobby,
                    DataNascimento = dataNascimento,
                    DataHoraInclusao = DateTime.UtcNow
                    },
                    new DesenvolvedorDto{
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Sexo = 'F',
                    Idade = 38,
                    Hobby = "Compras",
                    DataNascimento = Faker.DateOfBirth.Next(),
                    DataHoraInclusao = DateTime.UtcNow
                    }
                }
            );

            _controller = new DesenvolvedoresController(serviceMock.Object);
            var result = await _controller.GetAllByParamName("Fulano", 0, 1);
            Assert.True(result is OkObjectResult);
        }
    }
}
