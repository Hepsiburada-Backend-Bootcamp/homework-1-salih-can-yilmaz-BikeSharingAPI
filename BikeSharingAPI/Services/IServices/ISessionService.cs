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
        public List<Session> GetAll();
        public Session GetById(Guid id);
        public bool Create(Session session);
        public bool Delete(Guid id);
    }
}
