using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Services.IServices
{
    public interface ISessionRepository
    {
        List<Session> GetAll();
        List<Session> GetAll(Func<Session, bool> predicate);
        Session GetById(Guid id);
        bool Create(Session session);
        bool Update(Session session);
        bool Delete(Guid id);
    }
}
