using Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : DtoToModelProfile 
    {
        public EntityToDtoProfile(){
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();
        }
        
    }
}
