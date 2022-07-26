using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Service.Municipio;
using Moq;
using Xunit;


namespace api.Service.Test.Municipio
{
    public class QuandoForExecutarGetALL : MunicipioTestes
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMock;

        [Fact(DisplayName = "É Pssivel Executar Metodo GetAll")]

        public async Task E_Pssivel_Executar_Metodo_GetAll()
        {
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<MunicipioDto>();
            _serviceMock = new Mock<IMunicipioService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        
        }
    }
} 

