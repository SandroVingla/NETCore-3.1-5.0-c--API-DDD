using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Service.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api.Application.Test.Cep.QuandoRequisitarGet
{
    public class Retorno_NotFoud
    {
        private CepsController _controller;
        [Fact(DisplayName = "É Possivel Invocar realizar o get." )]

        public async Task E_Pssivel_Invocar_Controller_Create()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));


            _controller = new CepsController(serviceMock.Object);
         
            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);

        } 
    }
}
