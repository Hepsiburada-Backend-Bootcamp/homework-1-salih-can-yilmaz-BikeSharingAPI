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
        List<Session> GetAll(params string[] columns);
        List<Session> GetAll(string filter);
        List<Session> GetAll(string filter, params string[] columns);
        Session GetById(Guid Id);
        bool Create(Session session);
        bool Update(Session session);
        bool Delete(Guid Id);
    }
}
