using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Users;
using BikeSharingAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeSharingAPI.Helpers;

namespace BikeSharingAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogService LogService;
        public UserRepository(ILogService logService)
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

        public List<User> GetAll(Func<User, bool> wherePredicate)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Users.Where(wherePredicate).ToList();
            }
        }

        public List<User> GetAll(params string[] columns)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Users.SelectMembers(columns).ToList();
            }
        }

        public List<User> GetAll(Func<User, bool> wherePredicate, params string[] columns)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Users.SelectMembers(columns).Where(wherePredicate).ToList();
            }
        }

        public List<User> GetAll(string orderByParams)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Users.OrderBy(orderByParams).ToList();
            }
        }

        public List<User> GetAll(Func<User, bool> wherePredicate, string orderByParams)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Users.Where(wherePredicate).OrderBy(orderByParams).ToList();
            }
        }

        public List<User> GetAll(string orderByParams, params string[] columns)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Users.SelectMembers(columns).OrderBy(orderByParams).ToList();
            }
        }

        public List<User> GetAll(Func<User, bool> wherePredicate, string orderByParams, params string[] columns)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Users.SelectMembers(columns).Where(wherePredicate).OrderBy(orderByParams).ToList();
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
