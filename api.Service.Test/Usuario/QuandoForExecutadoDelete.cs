using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.User;
using Moq;
using Xunit;

namespace api.Service.Test.Usuario
{
    public class QuandoForExecutadoDelete : UsuarioTestes
    {
         private IUserService _service;
        private Mock<IUserService> _serviceMock;


        [Fact (DisplayName = "É possivel executar o método Delete.")]
        public async Task E_Possivel_Executar_Metodo_Delete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(IdUsuario))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(IdUsuario);
            Assert.True(deletado);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);

        }
    }
}
