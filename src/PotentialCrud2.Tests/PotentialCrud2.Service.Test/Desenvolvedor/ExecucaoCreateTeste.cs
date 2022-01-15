using System.Threading.Tasks;
using Moq;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Service.Test.Desenvolvedor
{
    public class ExecucaoCreateTeste : DesenvolvedorTeste
    {
        private IDesenvolvedorService _service;
        private Mock<IDesenvolvedorService> _serviceMock;

        [Fact(DisplayName = "Executar o método Create.")]
        public async Task Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IDesenvolvedorService>();
            _serviceMock.Setup(x => x.Post(desenvolvedorDtoCreate)).ReturnsAsync(desenvolvedorDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(desenvolvedorDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeDesenvolvedor, result.Nome);
            Assert.Equal(SexoDesenvolvedor, result.Sexo);
            Assert.Equal(IdadeDesenvolvedor, result.Idade);
            Assert.Equal(HobbyDesenvolvedor, result.Hobby);
            Assert.Equal(DataNascimentoDesenvolvedor, result.DataNascimento);
        }
    }
}
