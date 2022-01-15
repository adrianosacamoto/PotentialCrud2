using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PotentialCrud2.Application.Controllers;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Application.Test.Desenvolvedor.RequisicaoGet
{
    public class Retorno_Get
    {
        private DesenvolvedoresController _controller;

        [Fact(DisplayName = "Executar o método Get.")]
        public async Task Invocar_Controller_Get()
        {
            var serviceMock = new Mock<IDesenvolvedorService>();
            var nome = Faker.Name.FullName();
            var sexo = 'M';
            var idade = 25;
            var hobby = "Dormir";
            var dataNascimento = Faker.DateOfBirth.Next();

            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(
                new DesenvolvedorDto
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    Sexo = sexo,
                    Idade = idade,
                    Hobby = hobby,
                    DataNascimento = dataNascimento,
                    DataHoraInclusao = DateTime.UtcNow
                }
            );

            _controller = new DesenvolvedoresController(serviceMock.Object);
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as DesenvolvedorDto;
            Assert.NotNull(resultValue);
            Assert.Equal(nome, resultValue.Nome);
            Assert.Equal(sexo, resultValue.Sexo);
            Assert.Equal(idade, resultValue.Idade);
            Assert.Equal(hobby, resultValue.Hobby);
            Assert.Equal(dataNascimento, resultValue.DataNascimento);
        }
    }
}

