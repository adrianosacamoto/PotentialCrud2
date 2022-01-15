using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using PotentialCrud2.Domain.Dtos.Desenvolvedor;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Service.Test.Desenvolvedor
{
    public class ExecucaoGetAllTeste : DesenvolvedorTeste
    {
        private IDesenvolvedorService _service;
        private Mock<IDesenvolvedorService> _serviceMock;

        [Fact(DisplayName = "Executar o método GETALL.")]
        public async Task Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IDesenvolvedorService>();
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(listaDesenvolvedorDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<DesenvolvedorDto>();
            _serviceMock = new Mock<IDesenvolvedorService>();
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
