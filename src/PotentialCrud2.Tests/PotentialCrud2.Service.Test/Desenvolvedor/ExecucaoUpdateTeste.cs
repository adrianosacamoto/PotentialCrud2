using System.Threading.Tasks;
using Moq;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using Xunit;

namespace PotentialCrud2.Service.Test.Desenvolvedor
{
    public class ExecucaoUpdateTeste : DesenvolvedorTeste
    {
        private IDesenvolvedorService _service;
        private Mock<IDesenvolvedorService> _serviceMock;

        [Fact(DisplayName = "Executar o método Update.")]
        public async Task Executar_Metodo_Update()
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

            _serviceMock = new Mock<IDesenvolvedorService>();
            _serviceMock.Setup(x => x.Put(desenvolvedorDtoUpdate)).ReturnsAsync(desenvolvedorDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(desenvolvedorDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeDesenvolvedorAlterado, resultUpdate.Nome);
            Assert.Equal(SexoDesenvolvedorAlterado, resultUpdate.Sexo);
            Assert.Equal(IdadeDesenvolvedorAlterado, resultUpdate.Idade);
            Assert.Equal(HobbyDesenvolvedorAlterado, resultUpdate.Hobby);
            Assert.Equal(DataNascimentoDesenvolvedorAlterado, resultUpdate.DataNascimento);
        }
    }
}
