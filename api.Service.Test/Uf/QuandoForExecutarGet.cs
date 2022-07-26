using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Service.Uf;
using Moq;
using Xunit;

namespace api.Service.Test.Uf
{
    public class QuandoForExecutarGet : UfTestes
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Metodo Get.")]

        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(IdUf)).ReturnsAsync(ufDto);
            _service = _serviceMock.Object;

            var result =await _service.Get(IdUf);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUf);
            Assert.Equal(Nome, result.Nome);

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUf);
            Assert.Null(_record);

        }
    }
}
