using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PotentialCrud2.Application.Controllers;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Application.Test.Desenvolvedor.RequisicaoCreate
{
    public class Retorno_Created
    {
        private DesenvolvedoresController _controller;

        [Fact(DisplayName = "Executar o método Created.")]
        public async Task Invocar_Controller_Create()
        {
            var serviceMock = new Mock<IDesenvolvedorService>();
            var nome = Faker.Name.FullName();
            var sexo = 'M';
            var idade = 25;
            var hobby = "Dormir";
            var dataNascimento = Faker.DateOfBirth.Next();

            serviceMock.Setup(x => x.Post(It.IsAny<DesenvolvedorDtoCreate>())).ReturnsAsync(
                new DesenvolvedorDtoCreateResult
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

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var desenvolvedorDtoCreate = new DesenvolvedorDtoCreate
            {
                Nome = nome,
                Sexo = sexo,
                Idade = idade,
                Hobby = hobby,
                DataNascimento = dataNascimento
            };

            var result = await _controller.Post(desenvolvedorDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as DesenvolvedorDtoCreateResult;
            Assert.NotNull(resultValue);
            Assert.Equal(desenvolvedorDtoCreate.Nome, resultValue.Nome);
            Assert.Equal(desenvolvedorDtoCreate.Sexo, resultValue.Sexo);
            Assert.Equal(desenvolvedorDtoCreate.Idade, resultValue.Idade);
            Assert.Equal(desenvolvedorDtoCreate.Hobby, resultValue.Hobby);
            Assert.Equal(desenvolvedorDtoCreate.DataNascimento, resultValue.DataNascimento);
        }
    }
}
