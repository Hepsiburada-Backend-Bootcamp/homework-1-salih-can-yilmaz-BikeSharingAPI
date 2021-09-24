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
        public UserService(ILogService logService)
        {
            this.LogService = logService;
        }

        public List<User> GetAll()
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Users.ToList();
            }
        }

        public User GetById(int id)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Users.FirstOrDefault(user => user.Id == id);
            }
        }

        public bool Create(User user)
        {
            using (var db = new SQLiteEFContext())
            {
                db.Add(user);
                db.SaveChanges();
                return true;
            }
        }

        public bool Update(User user)
        {
            using (var db = new SQLiteEFContext())
            {
                db.Update(user);
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new SQLiteEFContext())
            {
                User user = new User();
                user.Id = id;

                db.Remove(user);
                db.SaveChanges();

                return true;
            }
        }
    }
}
