using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PotentialCrud2.Application.Controllers;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Application.Test.Desenvolvedor.RequisicaoGetAllByParam
{
    public class Retorno_BadRequest
    {
        private DesenvolvedoresController _controller;

        [Fact(DisplayName = "Executar o método GetAllByParam retornando BadRequest.")]
        public async Task Invocar_Controller_GetAllByParam_Com_Retorno_BadRequest()
        {
            var serviceMock = new Mock<IDesenvolvedorService>();

            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(
                new List<DesenvolvedorDto>
                {
                    new DesenvolvedorDto{
                    Id = Guid.NewGuid(),
                    Nome = Faker.Name.FullName(),
                    Sexo = 'M',
                    Idade = 32,
                    Hobby = "Viajar",
                    DataNascimento = Faker.DateOfBirth.Next(),
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
            _controller.ModelState.AddModelError("Id", "Formato inválido");
            var result = await _controller.GetAllByParamName("", 0, 1);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
