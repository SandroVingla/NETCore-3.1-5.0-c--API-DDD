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
    public class QuandoForExecutadoUpdate : CepTestes
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMock;

        [Fact(DisplayName = "É Pssivel Executar Metodo Update")]

        public async Task E_Pssivel_Executar_Metodo_Update()
        {
            _serviceMock = new Mock<ICepService>();
            _serviceMock.Setup(m => m.Put(cepDtoUpdate)).ReturnsAsync(cepDtoUpdateResult);
            _service = _serviceMock.Object;
            
            var resultUpdate = await _service.Put(cepDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(CepAlterado, resultUpdate.Cep);
            Assert.Equal(LogradouroAlterado, resultUpdate.Logradouro);
            Assert.Equal(NumeroAlterado, resultUpdate.Numero);
        }
    }
}