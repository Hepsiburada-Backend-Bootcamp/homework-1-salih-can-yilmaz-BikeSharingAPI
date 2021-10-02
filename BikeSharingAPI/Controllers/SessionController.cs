using AutoMapper;
using BikeSharingAPI.Enums;
using BikeSharingAPI.Helpers;
using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Sessions;
using BikeSharingAPI.Services.IServices;
using BikeSharingAPI.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BikeSharingAPI.Controllers
{
    [Route("api/v1/Sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ILogService _LogService;
        private readonly ISessionService _SessionService;

        public SessionController(ILogService logService, ISessionService sessionService)
        {
            this._LogService = logService;
            this._SessionService = sessionService;
        }

        /// <summary>
        /// Tum sessionlarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetSessionList(
            string filter = "",
            string orderByParams = "",
            string fields = ""
            )
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            try
            {
                List<SessionReadDTO> sessionReadDTOs = _SessionService.GetSessions(filter, orderByParams, fields);
                if (sessionReadDTOs != null && sessionReadDTOs.Count > 0)
                {
                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.OK,
                        sessionReadDTOs
                        );
                }
                else
                {
                    _LogService.Log(SharedData.MessageSessionsNotFound, EnumLogLevel.ERROR);

                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.NotFound,
                        new ErrorModel { ErrorMessage = SharedData.MessageSessionsNotFound }
                        );
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(ex.Message, EnumLogLevel.ERROR);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = ex.Message }
                    );
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
                SessionReadDTO sessionReadDTO = _SessionService.GetSession(id);

                if (sessionReadDTO != null)
                {
                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.OK,
                        sessionReadDTO
                        );
                }
                else
                {
                    _LogService.Log(SharedData.MessageSessionNotFound, EnumLogLevel.ERROR);

                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.NotFound,
                        new ErrorModel { ErrorMessage = SharedData.MessageSessionNotFound }
                        );
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(ex.Message, EnumLogLevel.ERROR);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = ex.Message }
                    );
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

            if (_SessionService.CreateSession(sessionCreateDTO))
            {
                return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                _LogService.Log(SharedData.MessageCantCreateSession, EnumLogLevel.ERROR);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = SharedData.MessageCantCreateSession }
                    );
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
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            if (_SessionService.UpdateSession(sessionUpdateDTO, true))
            {
                return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                _LogService.Log(SharedData.MessageCantUpdateSession, EnumLogLevel.ERROR);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = SharedData.MessageCantUpdateSession }
                    );
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

            if (_SessionService.UpdateSession(sessionUpdateDTO))
            {
                return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                _LogService.Log(SharedData.MessageCantUpdateSession, EnumLogLevel.ERROR);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = SharedData.MessageCantUpdateSession }
                    );
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

            _SessionService.DeleteSession(id);

            return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
        }
    }
}
