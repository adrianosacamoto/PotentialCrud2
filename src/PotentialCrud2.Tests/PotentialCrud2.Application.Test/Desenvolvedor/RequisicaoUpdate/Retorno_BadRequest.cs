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
    public class Retorno_BadRequest
    {
        private DesenvolvedoresController _controller;

        [Fact(DisplayName = "Executar o método Update retornando BadRequest.")]
        public async Task Invocar_Controller_Update_Com_Retorno_BadRequest()
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
            _controller.ModelState.AddModelError("Sexo", "É obrigatório");

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
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
