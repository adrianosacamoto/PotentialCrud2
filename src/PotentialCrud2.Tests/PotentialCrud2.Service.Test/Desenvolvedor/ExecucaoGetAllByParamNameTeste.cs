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
    public class ExecucaoGetAllByParamNameTeste : DesenvolvedorTeste
    {
        private IDesenvolvedorService _service;
        private Mock<IDesenvolvedorService> _serviceMock;

        [Fact(DisplayName = "Executar o método GETALLBYPARAMNAME.")]
        public async Task Executar_Metodo_GetAllByParamName()
        {
            _serviceMock = new Mock<IDesenvolvedorService>();
            _serviceMock.Setup(x => x.GetAllByParamName("Beltrano1", 0, 1)).ReturnsAsync(listaDesenvolvedorDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAllByParamName("Beltrano1", 0, 1);
            Assert.NotNull(result);
        }
    }
}
