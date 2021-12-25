using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Service.User
{
    public interface IloginService
    {
         Task<object> FindByLogin(UserEntity user);
    }
}
