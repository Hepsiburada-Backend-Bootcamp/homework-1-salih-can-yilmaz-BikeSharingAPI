using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Users;
using BikeSharingAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeSharingAPI.Tools;
using BikeSharingAPI.Helpers;

namespace BikeSharingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _Mapper;

        public UserService(IUserRepository userService, IMapper mapper)
        {
            this._UserRepository = userService;
            this._Mapper = mapper;
        }

        public UserReadDTO GetUser(int Id)
        {
            User userModel = _UserRepository.GetById(Id);

            UserReadDTO userReadDTO = _Mapper.Map<UserReadDTO>(userModel);

            return userReadDTO;            
        }

        public List<UserReadDTO> GetUsers(string filter, string orderByParams, string fields) 
        {
            List<User> userModel;

            if (!String.IsNullOrWhiteSpace(fields))
            {
                if(!fields.Split(',').Contains("Id"))
                {

                    fields = "Id," + fields;
                }

                if(!String.IsNullOrWhiteSpace(filter))
                {
                    userModel = _UserRepository.GetAll(filter, fields.Split(','));
                }
                userModel = _UserRepository.GetAll(fields.Split(','));
            }
            else if (!String.IsNullOrWhiteSpace(filter))
            {
                userModel = _UserRepository.GetAll(filter);
            }
            else
            {
                userModel = _UserRepository.GetAll();
            }

            List<UserReadDTO> userReadDTOs = _Mapper.Map<List<UserReadDTO>>(userModel);

            if(!String.IsNullOrWhiteSpace(orderByParams))
            {
                return userReadDTOs.OrderBy(orderByParams).ToList();
            }

            return userReadDTOs;
        }

        public bool CreateUser(UserCreateDTO userCreateDTO)
        {
            User user = _Mapper.Map<User>(userCreateDTO);

            return _UserRepository.Create(user);
        }

        public bool UpdateUser(UserUpdateDTO userUpdateDTO, bool setNullsToDefaults = false)
        {
            User user;

            if (setNullsToDefaults)
            {
                user = _Mapper.Map<User>(userUpdateDTO);
            }
            else
            {
                user = _UserRepository.GetById(userUpdateDTO.Id);

                if (user == null)
                {
                    return false;
                }

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserUpdateDTO, User>();
                    cfg.ForAllPropertyMaps(
                        pm => pm.TypeMap.SourceType == typeof(UserUpdateDTO),
                            (pm, c) => c.MapFrom(new IgnoreNullResolver(), pm.SourceMember.Name));
                });

                IMapper iMapper = config.CreateMapper();

                user = iMapper.Map(userUpdateDTO, user);
            }

            return _UserRepository.Update(user);
        }

        public bool DeleteUser(int Id)
        {
            return _UserRepository.Delete(Id);
        }
    }
}
