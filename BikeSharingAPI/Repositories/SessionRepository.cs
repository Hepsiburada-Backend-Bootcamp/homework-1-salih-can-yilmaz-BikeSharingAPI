using BikeSharingAPI.Helpers;
using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using BikeSharingAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace BikeSharingAPI.Services
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ILogService LogService;
        public SessionRepository(ILogService logService)
        {
            this.LogService = logService;
        }

        public List<Session> GetAll()
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Sessions.ToList();
            }
        }

        public List<Session> GetAll(params string[] columns)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Sessions.SelectMembers(columns).ToList();
            }
        }

        public List<Session> GetAll(string filter)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Sessions.Where(filter).ToList();
            }
        }

        public List<Session> GetAll(string filter, params string[] columns)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Sessions.Where(filter).SelectMembers(columns).ToList();
            }
        }


        public Session GetById(Guid Id)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Sessions.FirstOrDefault(session => session.Id == Id);
            }
        }

        public bool Create(Session session)
        {
            using (var db = new SQLiteEFContext())
            {
                db.Add(session);
                db.SaveChanges();
                return true;
            }
        }

        public bool Update(Session session)
        {
            using (var db = new SQLiteEFContext())
            {
                db.Update(session);
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(Guid Id)
        {
            using (var db = new SQLiteEFContext())
            {
                Session session = new Session();
                session.Id = Id;

                db.Remove(session);
                db.SaveChanges();

                return true;
            }
        }
    }
}
