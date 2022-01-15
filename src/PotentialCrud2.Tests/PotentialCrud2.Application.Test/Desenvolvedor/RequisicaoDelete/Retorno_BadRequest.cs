using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PotentialCrud2.Application.Controllers;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Application.Test.Desenvolvedor.RequisicaoDelete
{
    public class Retorno_BadRequest
    {
        private DesenvolvedoresController _controller;

        [Fact(DisplayName = "Executar o método Delete retornando BadRequest.")]
        public async Task Invocar_Controller_Delete_Com_Retorno_BadRequest()
        {
            var serviceMock = new Mock<IDesenvolvedorService>();
            serviceMock.Setup(x => x.Delete(It.IsAny<Guid>()))
                       .ReturnsAsync(false);

            _controller = new DesenvolvedoresController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}
