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
        private readonly ISQLiteService SQLiteService;
        public SessionService(ILogService logService, ISQLiteService sQLiteService)
        {
            this.LogService = logService;
            this.SQLiteService = sQLiteService;
        }

        public List<SessionModel> GetAll()
        {
            List<SessionModel> sessionModel = SQLiteService.GetAll<SessionModel>("Session");

            return sessionModel;
        }

        public List<SessionModel> GetAll(string whereCondition)
        {
            List<SessionModel> sessionModel = SQLiteService.GetAll<SessionModel>("Session", whereCondition);

            return sessionModel;
        }

        public bool CreateSession(SessionCreateDTO sessionCreateDTO)
        {
            return SQLiteService.Write<SessionCreateDTO>("Session", sessionCreateDTO);
        }
    }
}
