using Moq;

using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Service.Municipio;

using Xunit;
using api.Service.Test.Municipio;

namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutarCreate : MunicipioTestes
    {
        private IMunicipioService _service;

        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Pssivel Executar Metodo Create")]

        public async Task E_Pssivel_Executar_Metodo_Create()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Post(municipioDtoCreate)).ReturnsAsync(municipioDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(municipioDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);
            Assert.Equal(IdUf, result.Ufid);
        }
    }
}
