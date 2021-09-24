using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Services.IServices
{
    public interface IUserService
    {
        public List<UserModel> GetAll();
        public List<UserModel> GetAll(string whereCondition);
        public bool CreateUser(UserCreateDTO userCreateDTO);
    }
}
