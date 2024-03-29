using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Service.Test.Municipio;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Service.Cep;
using Moq;
using Xunit;

namespace api.Service.Test.Cep
{
    public class QuandoForExecutadoGet : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Pssivel Executar Metodo Get")]

        public async Task E_Pssivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(IdCep)).ReturnsAsync(cepDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdCep);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCep);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(LogradouroOriginal, result.Logradouro);


            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(CepOriginal)).ReturnsAsync(cepDto);
            _service = _serviceMock.Object;

            result = await _service.Get(CepOriginal);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCep);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(LogradouroOriginal, result.Logradouro);


            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}