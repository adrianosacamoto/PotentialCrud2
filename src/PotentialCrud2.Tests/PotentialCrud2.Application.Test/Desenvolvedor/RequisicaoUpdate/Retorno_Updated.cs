using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PotentialCrud2.Application.Controllers;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Application.Test.Desenvolvedor.RequisicaoUpdate
{
    public class Retorno_Updated
    {
        private DesenvolvedoresController _controller;

        [Fact(DisplayName = "Executar o método Update.")]
        public async Task Invocar_Controller_Update()
        {
            var serviceMock = new Mock<IDesenvolvedorService>();
            var nome = Faker.Name.FullName();
            var sexo = 'M';
            var idade = 25;
            var hobby = "Dormir";
            var dataNascimento = Faker.DateOfBirth.Next();

            serviceMock.Setup(x => x.Put(It.IsAny<DesenvolvedorDtoUpdate>())).ReturnsAsync(
                new DesenvolvedorDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    Sexo = sexo,
                    Idade = idade,
                    Hobby = hobby,
                    DataNascimento = dataNascimento,
                    DataHoraAlteracao = DateTime.UtcNow
                }
            );

            _controller = new DesenvolvedoresController(serviceMock.Object);

            var desenvolvedorDtoUpdate = new DesenvolvedorDtoUpdate
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Sexo = sexo,
                Idade = idade,
                Hobby = hobby,
                DataNascimento = dataNascimento
            };

            var result = await _controller.Put(desenvolvedorDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as DesenvolvedorDtoUpdateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(desenvolvedorDtoUpdate.Nome, resultValue.Nome);
            Assert.Equal(desenvolvedorDtoUpdate.Sexo, resultValue.Sexo);
            Assert.Equal(desenvolvedorDtoUpdate.Idade, resultValue.Idade);
            Assert.Equal(desenvolvedorDtoUpdate.Hobby, resultValue.Hobby);
            Assert.Equal(desenvolvedorDtoUpdate.DataNascimento, resultValue.DataNascimento);
        }
    }
}
