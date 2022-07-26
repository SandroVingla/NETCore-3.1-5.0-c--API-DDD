using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.Municipio;
using Moq;
using Xunit;

namespace api.Service.Test.Municipio
{
    public class QuandoForExecutarDelete : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Ppssivel Executar Metodo Delete")]

        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(IdMunicipio))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdMunicipio);
            Assert.True(deletado);

            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);


        }
        
    }
}
