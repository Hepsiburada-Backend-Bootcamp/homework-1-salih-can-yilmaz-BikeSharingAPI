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
        public List<User> GetAll();
        public User GetById(int id);
        public bool Create(User user);
        public bool Update(User user);
        public bool Delete(int id);
    }
}
