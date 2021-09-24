using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using BikeSharingAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Session> GetAll(Func<Session, bool> predicate)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Sessions.Where(predicate).ToList();
            }
        }

        public Session GetById(Guid id)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Sessions.FirstOrDefault(session => session.Id == id);
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

        public bool Delete(Guid id)
        {
            using (var db = new SQLiteEFContext())
            {
                Session session = new Session();
                session.Id = id;

                db.Remove(session);
                db.SaveChanges();

                return true;
            }
        }
    }
}
