using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using BikeSharingAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Services
{
    public class SessionService : ISessionService
    {
        private readonly ILogService LogService;
        public SessionService(ILogService logService)
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

        public Session GetById(Guid id)
        {
            using (var db = new SQLiteEFContext())
            {
                return db.Sessions.FirstOrDefault(session => session.Id == id);
            }
        }

        public bool CreateSession(Session session)
        {
            using (var db = new SQLiteEFContext())
            {
                db.Add(session);
                db.SaveChanges();
                return true;
            }
        }
    }
}
