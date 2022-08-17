using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Service.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api.Application.Test.Municipio.QuandoRequisitarGet
{
    public class Retorno_NotFound
    {
        private MunicipiosController _controller;
        [Fact(DisplayName = "É Possivel Invocar realizar o get." )]

        public async Task E_Pssivel_Invocar_Controller_Create()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDto)null));

            _controller = new MunicipiosController(serviceMock.Object);
         
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);

        } 
            
    }
}
