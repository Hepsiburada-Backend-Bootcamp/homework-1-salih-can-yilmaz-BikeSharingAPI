using BikeSharingAPI.Enums;
using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using BikeSharingAPI.Services.IServices;
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
        private readonly ILogService LogService;
        private readonly ISessionService SessionService;

        public SessionController(ILogService logService, ISessionService sessionService)
        {
            this.LogService = logService;
            this.SessionService = sessionService;
        }

        /// <summary>
        /// Tum sessionlarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetSessionList()
        {
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            try
            {
                List<Session> sessionModel = SessionService.GetAll();

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
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            try
            {
                Session sessionModel = SessionService.GetById(id);

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
        /// Body'den okudugu model ile yeni bir user yaratir.
        /// </summary>
        /// <param name="sessionCreateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateSession(
            [FromBody] Session session
            )
        {
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            if (SessionService.Create(session))
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
        public IActionResult PutSession([FromBody]SessionUpdateDTO sessionUpdateDTO)
        {
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            return NoContent();
        }

        /// <summary>
        /// Id ile eşleştirdiği kaydi verilen degerler ile veritabanında gunceller.
        /// </summary>
        /// <param name="sessionUpdateDTO"></param>
        /// <returns>if succeeds 204; if fails 400 or 500</returns>
        [HttpPatch]
        public IActionResult PatchSession([FromBody] SessionUpdateDTO sessionUpdateDTO)
        {
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            return NoContent();
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
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            SessionService.Delete(id);

            return Ok();
        }
    }
}
