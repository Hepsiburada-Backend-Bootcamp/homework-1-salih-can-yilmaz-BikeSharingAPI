using AutoMapper;
using BikeSharingAPI.Enums;
using BikeSharingAPI.Helpers;
using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Users;
using BikeSharingAPI.Services;
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
    [Route("api/v1/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogService _LogService;
        private readonly IUserService _UserService;

        public UserController(ILogService logService, IUserService userService)
        {
            this._LogService = logService;
            this._UserService = userService;
            
        }

        /// <summary>
        /// Tum kullanicilarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetUserList(
            string filter = "",
            string orderByParams = "",
            string fields = ""
            )
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            try
            {
                List<UserReadDTO> userReadDTOs = _UserService.GetUsers(filter, orderByParams, fields);

                if (userReadDTOs != null && userReadDTOs.Count > 0)
                {
                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.OK,
                        userReadDTOs
                        );
                }
                else
                {
                    _LogService.Log(SharedData.MessageUsersNotFound, EnumLogLevel.ERROR);

                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.NotFound,
                        new ErrorModel { ErrorMessage = SharedData.MessageUsersNotFound }
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
        /// Id'si verilen kullaniciyi doner.
        /// </summary>
        /// <param name="id">Kullanici id'si</param>
        /// <returns>Eger bulursa, kullanici bilgileri json formatinda.</returns>
        [Route("{id}")]
        [Route("{id}/Sessions")]
        [HttpGet]
        public IActionResult GetUser([FromRoute]int id)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);
            try
            {
                if (HttpContext.Request.Path.Value.Contains("/Sessions"))
                {
                    return RedirectToAction("GetSessionList", "Session", new { filter = $"UserId = {id}" });
                }

                UserReadDTO userReadDTO = _UserService.GetUser(id);

                if (userReadDTO != null)
                {
                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.OK,
                        userReadDTO
                        );
                }
                else
                {
                    _LogService.Log(SharedData.MessageUserNotFound, EnumLogLevel.ERROR);

                    return HelperResponse.GenerateResponse(
                        EnumResponseFormat.JSON,
                        HttpStatusCode.NotFound,
                        new ErrorModel { ErrorMessage = SharedData.MessageUserNotFound }
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
        /// Body'den okudugu model ile yeni bir user yaratir.
        /// </summary>
        /// <param name="userCreateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser(
            [FromBody] UserCreateDTO userCreateDTO
            )
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            if (_UserService.CreateUser(userCreateDTO))
            {
                return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                _LogService.Log(SharedData.MessageCantCreateUser, EnumLogLevel.ERROR);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = SharedData.MessageCantCreateUser }
                    );
            }
        }

        /// <summary>
        /// Id ile eşleştirdiği kaydi verilen degerler ile veritabanında gunceller. Degeri belirtilmeyen
        /// alanlara o alanlarin default degeri atanir.
        /// </summary>
        /// <param name="userUpdateDTO"></param>
        /// <returns>if succeeds 204; if fails 400 or 500</returns>
        [HttpPut]
        public IActionResult PutUser([FromBody] UserUpdateDTO userUpdateDTO)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            if (_UserService.UpdateUser(userUpdateDTO, true))
            {
                return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                _LogService.Log(SharedData.MessageCantUpdateUser, EnumLogLevel.ERROR);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = SharedData.MessageCantUpdateUser }
                    );
            }
        }

        /// <summary>
        /// Id ile eşleştirdiği kaydi verilen degerler ile veritabanında gunceller.
        /// </summary>
        /// <param name="userUpdateDTO"></param>
        /// <returns>if succeeds 204; if fails 400 or 500</returns>
        [HttpPatch]
        public IActionResult PatchUser([FromBody] UserUpdateDTO userUpdateDTO)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            if (_UserService.UpdateUser(userUpdateDTO))
            {
                return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                _LogService.Log(SharedData.MessageCantUpdateUser, EnumLogLevel.ERROR);

                return HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.InternalServerError,
                    new ErrorModel { ErrorMessage = SharedData.MessageCantUpdateUser }
                    );
            }
        }

        /// <summary>
        /// Id'si verilen User icin veritabanindan silme islemi yapar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            _UserService.DeleteUser(id);

            return HelperResponse.GenerateResponse(HttpStatusCode.NoContent);
        }
    }
}
