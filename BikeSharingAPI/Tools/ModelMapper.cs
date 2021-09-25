using AutoMapper;
using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using BikeSharingAPI.Models.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Tools
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserReadDTO>();
            CreateMap<UserUpdateDTO, User>();

            CreateMap<SessionCreateDTO, Session>();
            CreateMap<Session, SessionReadDTO>();
            CreateMap<SessionUpdateDTO, Session>();
        }
    }
}
