using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Services.IServices
{
    public interface IUserRepository
    {
        List<User> GetAll();
        List<User> GetAll(Func<User, bool> wherePredicate);
        List<User> GetAll(params string[] columns);
        List<User> GetAll(Func<User, bool> wherePredicate, params string[] columns);
        User GetById(int id);
        bool Create(User user);
        bool Update(User user);
        bool Delete(int id);
    }
}
