using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;

namespace Api.Domain.Interfaces.Service.Uf
{
    public interface IUfService
    {
         Task<UfDto> Get(Guid id);
         Task<IEnumerable<UfDto>> GetAll();
    }
}
