using System;
using System.Threading.Tasks;
using Moq;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Service.Test.Desenvolvedor
{
    public class ExecucaoGetTeste : DesenvolvedorTeste
    {
        private IDesenvolvedorService _service;
        private Mock<IDesenvolvedorService> _serviceMock;

        [Fact(DisplayName = "Executar o método GET.")]
        public async Task Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IDesenvolvedorService>();
            _serviceMock.Setup(x => x.Get(IdDesenvolvedor)).ReturnsAsync(desenvolvedorDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdDesenvolvedor);
            Assert.NotNull(result);
            Assert.True(result.Id == IdDesenvolvedor);
            Assert.Equal(NomeDesenvolvedor, result.Nome);

            _serviceMock = new Mock<IDesenvolvedorService>();
            _serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult((DesenvolvedorDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdDesenvolvedor);
            Assert.Null(_record);
        }
    }
}
