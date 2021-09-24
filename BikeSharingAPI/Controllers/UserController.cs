using BikeSharingAPI.Enums;
using BikeSharingAPI.Models;
using BikeSharingAPI.Models.DTOs.Users;
using BikeSharingAPI.Services;
using BikeSharingAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Controllers
{
    [Route("api/v1/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogService LogService;
        private readonly IUserService UserService;

        public UserController(ILogService logService, IUserService userService)
        {
            this.LogService = logService;
            this.UserService = userService;
        }
        /// <summary>
        /// Tum kullanicilarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetUserList()
        {
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            try
            {                
                List<User> userModel = UserService.GetAll();

                if(userModel != null && userModel.Count > 0)
                {
                    return Ok(userModel);
                }
                else
                {
                    return NotFound(SharedData.MessageUsersNotFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Id'si verilen kullaniciyi doner.
        /// </summary>
        /// <param name="id">Kullanici id'si</param>
        /// <returns>Eger bulursa, kullanici bilgileri json formatinda.</returns>
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetUser([FromRoute]int id)
        {
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);
            try
            {
                User userModel = UserService.GetById(id);

                if(userModel != null)
                {
                    return Ok(userModel);
                }
                else
                {
                    return NotFound(SharedData.MessageUserNotFound);
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
        /// <param name="userCreateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUser(
            [FromBody] User user
            )
        {
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            if (UserService.Create(user))
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
        /// <param name="userUpdateDTO"></param>
        /// <returns>if succeeds 204; if fails 400 or 500</returns>
        [HttpPut]
        public IActionResult PutUser([FromBody] User userUpdateDTO)
        {
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            if(UserService.Update(userUpdateDTO))
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
        /// <param name="userUpdateDTO"></param>
        /// <returns>if succeeds 204; if fails 400 or 500</returns>
        [HttpPatch]
        public IActionResult PatchUser([FromBody] User userUpdateDTO)
        {
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            if (UserService.Update(userUpdateDTO))
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
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
            LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            UserService.Delete(id);

            return Ok();
        }
    }
}
