using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PotentialCrud2.Application.Controllers;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Application.Test.Desenvolvedor.RequisicaoDelete
{
    public class Retorno_Deleted
    {
        private DesenvolvedoresController _controller;

        [Fact(DisplayName = "Executar o método Delete.")]
        public async Task Invocar_Controller_Delete()
        {
            var serviceMock = new Mock<IDesenvolvedorService>();

            serviceMock.Setup(x => x.Delete(It.IsAny<Guid>()))
                       .ReturnsAsync(true);

            _controller = new DesenvolvedoresController(serviceMock.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is StatusCodeResult);
        }
    }
}
