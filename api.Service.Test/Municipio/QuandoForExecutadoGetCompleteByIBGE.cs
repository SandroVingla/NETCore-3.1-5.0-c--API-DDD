using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Service.Test.Municipio;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Service.Municipio;
using Api.Domain.Interfaces.Service.Uf;
using Moq;
using Xunit;


namespace Api.Service.Test.Municipio
{
    public class QuandoForExecutadoGetCompleteByIBGE : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "E Possivel Executar o Metodo GET Complete By IBGE")]

        public async Task E_Possivel_Executar_Metodo_Get_Complete_By_IBGE()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(CodigoIBGEMunicipio)).ReturnsAsync(municipioDtoCompleto);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteByIBGE(CodigoIBGEMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodigoIBGEMunicipio, result.CodIBGE);
            Assert.NotNull(result.Uf);
        }
        

    }
}