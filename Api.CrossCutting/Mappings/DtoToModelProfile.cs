using Api.Data.Mapping;
using Api.Domain.Dtos.User;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserMap, UserDto>()
                    .ReverseMap();
        }
    }
}
