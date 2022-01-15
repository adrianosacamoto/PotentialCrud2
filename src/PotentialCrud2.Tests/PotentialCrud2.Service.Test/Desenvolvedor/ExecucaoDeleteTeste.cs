using System;
using System.Threading.Tasks;
using Moq;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Service.Test.Desenvolvedor
{
    public class ExecucaoDeleteTeste : DesenvolvedorTeste
    {
        private IDesenvolvedorService _service;
        private Mock<IDesenvolvedorService> _serviceMock;

        [Fact(DisplayName = "Executar o método Delete.")]
        public async Task Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IDesenvolvedorService>();
            _serviceMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var resultDeletado = await _service.Delete(IdDesenvolvedor);
            Assert.True(resultDeletado);
        }
    }
}
