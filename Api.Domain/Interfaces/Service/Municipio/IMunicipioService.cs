using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;

namespace Api.Domain.Interfaces.Service.Municipio
{
    public interface IMunicipioService
    {
         Task<MunicipioDto> Get(Guid id);
         Task<MunicipioDtoCompleto> GetCompleteById( Guid id);
         Task<MunicipioDtoCompleto> GetCompleteByIBGE(Guid codIBGE);
         Task<IEnumerable<MunicipioDto>> GetAll();
         Task<MunicipioDtoCreateResult> Post(MunicipioDtoCreate municipio);
         Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio);
         Task<bool> Delete(Guid id);
         
         
    }
}
