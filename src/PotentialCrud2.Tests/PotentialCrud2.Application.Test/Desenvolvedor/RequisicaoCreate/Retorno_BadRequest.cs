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
    public class Retorno_BadRequest
    {
        private DesenvolvedoresController _controller;

        [Fact(DisplayName = "Executar o método Created retornando BadRequest.")]
        public async Task Invocar_Controller_Create_Com_Retorno_BadRequest()
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
            _controller.ModelState.AddModelError("Nome", "É obrigatório");

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
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
