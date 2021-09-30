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
    public class SessionRepository : ISessionRepository//todo repository base and async methods, new ile turememesi lazim, her islemden sonra db.savechanges yapilmamali context icerisinde scoped olmasi lazim
    {
        private readonly ILogService _logService;
        private readonly SQLiteEFContext _sQLiteEFContext;
        public SessionRepository(ILogService logService, SQLiteEFContext sQLiteEFContext)
        {
            this._logService = logService;
            this._sQLiteEFContext = sQLiteEFContext;
        }

        public List<Session> GetAll()
        {
            return this._sQLiteEFContext.Sessions.ToList();
            
        }

        public List<Session> GetAll(params string[] columns)
        {
            return this._sQLiteEFContext.Sessions.SelectMembers(columns).ToList();
        }

        public List<Session> GetAll(string filter)
        {
            return this._sQLiteEFContext.Sessions.Where(filter).ToList();
        }

        public List<Session> GetAll(string filter, params string[] columns)
        {
            return this._sQLiteEFContext.Sessions.Where(filter).SelectMembers(columns).ToList();
        }


        public Session GetById(Guid Id)
        {
            return this._sQLiteEFContext.Sessions.FirstOrDefault(session => session.Id == Id);
        }

        public bool Create(Session session)
        {
            this._sQLiteEFContext.Add(session);
            this._sQLiteEFContext.SaveChanges();
            return true;
        }

        public bool Update(Session session)
        {
            this._sQLiteEFContext.Update(session);
            this._sQLiteEFContext.SaveChanges();
            return true;
        }

        public bool Delete(Guid Id)
        {
            Session session = new Session();
            session.Id = Id;

            this._sQLiteEFContext.Remove(session);
            this._sQLiteEFContext.SaveChanges();

            return true;
        }
    }
}
