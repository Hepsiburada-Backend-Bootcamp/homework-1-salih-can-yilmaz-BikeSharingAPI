using AutoMapper;
using BikeSharingAPI.Enums;
using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using BikeSharingAPI.Services.IServices;
using BikeSharingAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Controllers
{
    [Route("api/v1/Sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ILogService _LogService;
        private readonly ISessionService _SessionService;
        private readonly IMapper _Mapper;

        public SessionController(ILogService logService, ISessionService sessionService, IMapper mapper)
        {
            this._LogService = logService;
            this._SessionService = sessionService;
            this._Mapper = mapper;
        }

        /// <summary>
        /// Tum sessionlarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetSessionList()
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            try
            {
                List<Session> sessionModel = _SessionService.GetAll();

                if (sessionModel != null && sessionModel.Count > 0)
                {
                    return Ok(sessionModel);
                }
                else
                {
                    return NotFound(SharedData.MessageSessionsNotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Id'si verilen sessioni doner.
        /// </summary>
        /// <param name="id">Kullanici id'si</param>
        /// <returns>Eger bulursa, session bilgileri json formatinda.</returns>
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetSession([FromRoute] Guid id)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            try
            {
                Session sessionModel = _SessionService.GetById(id);

                if (sessionModel != null)
                {
                    return Ok(sessionModel);
                }
                else
                {
                    return NotFound(SharedData.MessageSessionNotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Body'den okudugu model ile yeni bir session yaratir.
        /// </summary>
        /// <param name="sessionCreateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateSession(
            [FromBody] SessionCreateDTO sessionCreateDTO
            )
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            Session session = _Mapper.Map<Session>(sessionCreateDTO);

            if (_SessionService.Create(session))
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Id ile eşleştirdiği kaydi verilen degerler ile veritabanında gunceller. Degeri belirtilmeyen
        /// alanlara o alanlarin default degeri atanir.
        /// </summary>
        /// <param name="sessionUpdateDTO"></param>
        /// <returns>if succeeds 204; if fails 400 or 500</returns>
        [HttpPut]
        public IActionResult PutSession([FromBody]Session sessionUpdateDTO)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            Session session = _Mapper.Map<Session>(sessionUpdateDTO);

            if (_SessionService.Update(session))
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Id ile eşleştirdiği kaydi verilen degerler ile veritabanında gunceller.
        /// </summary>
        /// <param name="sessionUpdateDTO"></param>
        /// <returns>if succeeds 204; if fails 400 or 500</returns>
        [HttpPatch]
        public IActionResult PatchSession([FromBody] SessionUpdateDTO sessionUpdateDTO)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            Session session = _SessionService.GetById(sessionUpdateDTO.Id);

            if (session == null)
            {
                return NotFound();
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

            if (_SessionService.Update(session))
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Id'si verilen Session icin veritabanindan silme islemi yapar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSession([FromRoute] Guid id)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            _SessionService.Delete(id);

            return Ok();
        }
    }
}
