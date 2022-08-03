using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Service.Test.Municipio;
using Api.Domain.Interfaces.Service.Cep;
using Moq;
using Xunit;

namespace api.Service.Test.Cep 
{
    public class QuandoForExecutadoCreate : CepTestes
    {
        private ICepService _service;

        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "E possivel executar o metodo create.")]

        public async Task E_possivel_executar_metodo_create()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Post(cepDtoCreate)).ReturnsAsync(cepDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(cepDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CepOriginal, result.Cep);
            Assert.Equal(LogradouroOriginal, result.Logradouro);
            Assert.Equal(NumeroOriginal, result.Numero);
        }
    }
}