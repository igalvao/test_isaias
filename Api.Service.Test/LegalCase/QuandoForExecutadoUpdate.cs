using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.LegalCase;
using Moq;
using Xunit;

namespace Api.Service.Test.LegalCase
{
    public class QuandoForExecutadoUpdate : LegalCaseTestes
    {
        private ILegalCaseService _service;
        private Mock<ILegalCaseService> _serviceMock;

        [Fact(DisplayName = "É Possivel executar o Método Update.")]
        public async Task E_Possivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<ILegalCaseService>();
            _serviceMock.Setup(m => m.Post(LegalCaseDtoCreate)).ReturnsAsync(LegalCaseDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(LegalCaseDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeLegalCase, result.Name);
            Assert.Equal(CourtNameLegalCase, result.CourtName);

            _serviceMock = new Mock<ILegalCaseService>();
            _serviceMock.Setup(m => m.Put(LegalCaseDtoUpdate)).ReturnsAsync(LegalCaseDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(LegalCaseDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeLegalCaseAlterado, resultUpdate.Name);
            Assert.Equal(CourtNameLegalCaseAlterado, resultUpdate.CourtName);

        }
    }
}
