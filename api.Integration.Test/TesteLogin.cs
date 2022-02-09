using System.Threading.Tasks;
using Xunit;

namespace api.Integration.Test
{

    public class TesteLogin : BaseIntegration
    {
        [Fact]
        public async Task TesteDoToken()
        {
            await AdicionarToken();
        }
    }
}
