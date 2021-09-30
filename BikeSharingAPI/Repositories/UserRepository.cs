using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Users;
using BikeSharingAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeSharingAPI.Helpers;
using System.Linq.Dynamic.Core;

namespace BikeSharingAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogService LogService;
        private readonly SQLiteEFContext _sQLiteEFContext;
        public UserRepository(ILogService logService, SQLiteEFContext sQLiteEFContext)
        {
            this.LogService = logService;
            this._sQLiteEFContext = sQLiteEFContext;
        }

        public List<User> GetAll()
        {
            return this._sQLiteEFContext.Users.ToList();
        }

        public List<User> GetAll(params string[] columns)
        {
            return this._sQLiteEFContext.Users.SelectMembers(columns).ToList();
        }
        public List<User> GetAll(string filter)
        {
            return this._sQLiteEFContext.Users.Where(filter).ToList();
        }

        public List<User> GetAll(string filter, params string[] columns)
        {
            return this._sQLiteEFContext.Users.Where(filter).SelectMembers(columns).ToList();
        }

        public User GetById(int id)
        {
            return this._sQLiteEFContext.Users.FirstOrDefault(user => user.Id == id);
        }

        public bool Create(User user)
        {
            this._sQLiteEFContext.Add(user);
            this._sQLiteEFContext.SaveChanges();
            return true;
        }

        public bool Update(User user)
        {
            this._sQLiteEFContext.Update(user);
            this._sQLiteEFContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            User user = new User();
            user.Id = id;

            this._sQLiteEFContext.Remove(user);
            this._sQLiteEFContext.SaveChanges();

            return true;
        }
    }
}
