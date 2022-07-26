using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Service.Municipio;
using Moq;
using Xunit;

namespace api.Service.Test.Municipio
{
    public class QuandoForExecutarUpdate : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Pssivel Executar Metodo Update")]

        public async Task E_Pssivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Put(municipioDtoUpdate)).ReturnsAsync(municipioDtoUpdateResult);
            _service = _serviceMock.Object;
            
            var resultUpdate = await _service.Put(municipioDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeMunicipioAlterado, resultUpdate.Nome);
            Assert.Equal(CodigoIBGEMunicipioAlterado, resultUpdate.CodIBGE);
            Assert.Equal(IdUf, resultUpdate.Ufid);
        }
    }
    
}
