using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Moq;
using Xunit;

namespace api.Service.Test.Usuario
{
    public class QuandoForExecutadoGetAll : UsuarioTestes
    {
        
        private IUserService _service;
        private Mock<IUserService> _serviceMock;


        [Fact (DisplayName = "É possivel executar o método GETAll.")]
        public async Task E_Possivel_Executar_Metodo_GetAll()
        {

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count()==10);


            var _listaResult = new List<UserDto>();
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listaResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpyt = await _service.GetAll();
            Assert.Empty(_resultEmpyt);
            Assert.True(_resultEmpyt.Count() == 0);
        }
    }
}
