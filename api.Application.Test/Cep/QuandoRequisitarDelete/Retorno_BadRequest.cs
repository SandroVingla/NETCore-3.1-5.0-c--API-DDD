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

namespace api.Application.Test.Cep.QuandoRequisitarDelete
{
    public class Retorno_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "E_Possivel_Realizar_DEleted")]

        public async Task E_Possivel_Invocar_A_Controller_Delete()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(true);

            _controller = new CepsController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido!");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
