using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Services.IServices
{
    public interface ISessionService
    {
        public List<SessionModel> GetAll();
        public List<SessionModel> GetAll(string whereCondition);
        public bool CreateSession(SessionCreateDTO sessionCreateDTO);
    }
}
