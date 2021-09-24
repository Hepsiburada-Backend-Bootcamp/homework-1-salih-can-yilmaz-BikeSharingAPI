using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Users;
using BikeSharingAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ILogService LogService;
        private readonly ISQLiteService SQLiteService;
        public UserService(ILogService logService, ISQLiteService sQLiteService)
        {
            this.LogService = logService;
            this.SQLiteService = sQLiteService;
        }

        public List<UserModel> GetAll()
        {
            List<UserModel> userModel = new List<UserModel>();
            userModel = SQLiteService.GetAll<UserModel>("User");

            return userModel;
        }

        public List<UserModel> GetAll(string whereCondition)
        {
            List<UserModel> userModel = new List<UserModel>();
            userModel = SQLiteService.GetAll<UserModel>("User", whereCondition);

            return userModel;
        }

        public bool CreateUser(UserCreateDTO userCreateDTO)
        {
            return SQLiteService.Write<UserCreateDTO>("User", userCreateDTO);
        }
    }
}
