using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using BikeSharingAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BikeSharingAPI.Tools;

namespace BikeSharingAPI.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _SessionRepository;
        private readonly IMapper _Mapper;

        public SessionService(ISessionRepository sessionService, IMapper mapper)
        {
            this._SessionRepository = sessionService;
            this._Mapper = mapper;
        }

        public SessionReadDTO GetSession(Guid Id)
        {
            Session sessionModel = _SessionRepository.GetById(Id);

            SessionReadDTO sessionReadDTO = _Mapper.Map<SessionReadDTO>(sessionModel);

            return sessionReadDTO;
        }

        public List<SessionReadDTO> GetSessions(string fields)
        {
            List<Session> sessionModel;

            if (fields != "")
            {
                sessionModel = _SessionRepository.GetAll(fields.Split(','));
            }
            else
            {
                sessionModel = _SessionRepository.GetAll();
            }



            List<SessionReadDTO> sessionReadDTOs = _Mapper.Map<List<SessionReadDTO>>(sessionModel);


            return sessionReadDTOs;
        }

        public bool CreateSession(SessionCreateDTO sessionCreateDTO)
        {
            Session session = _Mapper.Map<Session>(sessionCreateDTO);

            return _SessionRepository.Create(session);
        }

        public bool UpdateSession(SessionUpdateDTO sessionUpdateDTO, bool setNullsToDefaults = false)
        {
            Session session;

            if (setNullsToDefaults)
            {
                session = _Mapper.Map<Session>(sessionUpdateDTO);
            }
            else
            {
                session = _SessionRepository.GetById(sessionUpdateDTO.Id);

                if (session == null)
                {
                    return false;
                }

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SessionUpdateDTO, Session>();
                    cfg.ForAllPropertyMaps(
                        pm => pm.TypeMap.SourceType == typeof(SessionUpdateDTO),
                            (pm, c) => c.MapFrom(new IgnoreNullResolver(), pm.SourceMember.Name));
                });

                IMapper iMapper = config.CreateMapper();

                session = iMapper.Map(sessionUpdateDTO, session);
            }

            return _SessionRepository.Update(session);
        }

        public bool DeleteSession(Guid Id)
        {
            return _SessionRepository.Delete(Id);
        }
    }
}
