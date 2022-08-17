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

namespace api.Application.Test.Municipio.QuandoRequisitarGetAll
{
    public class Retorno_BadRequest
    {
        private MunicipiosController _controller;
        [Fact(DisplayName = "É Possivel Realizar Get." )]

        public async Task E_Pssivel_Invocar_Controller_GetAll()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<MunicipioDto>
                {
                    new MunicipioDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = "São Paulo"
                    },
                    new MunicipioDto
                    {
                        Id = Guid.NewGuid(),
                        Nome = "Limeira"
                    }
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio,");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);

           
        }
    }
}
