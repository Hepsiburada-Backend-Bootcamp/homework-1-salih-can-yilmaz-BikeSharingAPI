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
        List<User> GetAll();
        List<User> GetAll(Func<User, bool> predicate);
        User GetById(int id);
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}
