using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Api.Service.Test;
using Xunit;

namespace api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É Possivel mapear modelos.")]
        public void E_Possivel_mapear_os_Modelos()
        {
           var model = new UserModel
           {
               Id = Guid.NewGuid(),
               Name = Faker.Name.FullName(),
               Email = Faker.Internet.Email(),
               CreateAt = DateTime.UtcNow,
               UpdateAt = DateTime.UtcNow
           };

           var listaEntity = new List<UserEntity>();
           for (int i = 0 ; i < 5 ; i++)
           {
               var item = new UserEntity
               {
                  
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow 
               };
               listaEntity.Add(item);
               
           }

           //Model => Entity
           var Entity = Mapper.Map<UserEntity>(model);
           Assert.Equal(Entity.Id, model.Id);
           Assert.Equal(Entity.Name, model.Name);
           Assert.Equal(Entity.Email, model.Email);
           Assert.Equal(Entity.CreateAt, model.CreateAt);
           Assert.Equal(Entity.UpdateAt, model.UpdateAt);

           //Entity para Dto
           var userDto = Mapper.Map<UserDto>(Entity);
           Assert.Equal(userDto.Id, Entity.Id);
           Assert.Equal(userDto.Name, Entity.Name);
           Assert.Equal(userDto.Email, Entity.Email);
           Assert.Equal(userDto.CreateAt, Entity.CreateAt);

           var listaDto = Mapper.Map<List<UserDto>>(listaEntity);
           Assert.True(listaDto.Count() == listaEntity.Count());
           for (int i = 0; i < listaDto.Count(); i++)
           {
               Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
               Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
               Assert.Equal(listaDto[i].Email, listaEntity[i].Email);
               Assert.Equal(listaDto[i].CreateAt, listaEntity[i].CreateAt);
           }

           var userDtoCreateResult = Mapper.Map<UserDtoCreateResult>(Entity);

           Assert.Equal(userDtoCreateResult.Id, Entity.Id);
           Assert.Equal(userDtoCreateResult.Name, Entity.Name);
           Assert.Equal(userDtoCreateResult.Email, Entity.Email);
           Assert.Equal(userDtoCreateResult.CreateAt, Entity.CreateAt);


           var userDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(Entity);

           Assert.Equal(userDtoUpdateResult.Id, Entity.Id);
           Assert.Equal(userDtoUpdateResult.Name, Entity.Name);
           Assert.Equal(userDtoUpdateResult.Email, Entity.Email);
           Assert.Equal(userDtoUpdateResult.UpdateAt, Entity.UpdateAt);


           //Dto para model
           var userModel = Mapper.Map<UserModel>(userDto);

           Assert.Equal(userModel.Id, userDto.Id);
           Assert.Equal(userModel.Name, userDto.Name);
           Assert.Equal(userModel.Email, userDto.Email);
           Assert.Equal(userModel.CreateAt, userDto.CreateAt);

           //Dtocreate para model
           var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);

           Assert.Equal(userDtoCreate.Name, userModel.Name);
           Assert.Equal(userDtoCreate.Email, userModel.Email);


           var userDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
           Assert.Equal(userDtoUpdate.Id, userModel.Id);
           Assert.Equal(userDtoUpdate.Name, userModel.Name);
           Assert.Equal(userDtoUpdate.Email, userModel.Email);

           
        }
        
    }
}
