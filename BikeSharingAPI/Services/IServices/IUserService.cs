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
        public UserReadDTO GetUser(int Id);
        public List<UserReadDTO> GetUsers(string filter, string orderByParams, string fields);
        public bool CreateUser(UserCreateDTO userCreateDTO);
        bool UpdateUser(UserUpdateDTO userUpdateDTO, bool setNullsToDefaults = false);
        public bool DeleteUser(int Id);

    }
}
