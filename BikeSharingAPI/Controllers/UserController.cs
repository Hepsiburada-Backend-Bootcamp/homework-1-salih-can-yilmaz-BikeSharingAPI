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
        private readonly ISQLiteService SQLiteService;
        
        public UserController(ILogService logService, ISQLiteService sQLiteService)
        {
            this.LogService = logService;
            this.SQLiteService = sQLiteService;
        }
        /// <summary>
        /// Tum kullanicilarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetUserList()
        {
            try
            {
                LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);
                List<UserModel> userModel = new List<UserModel>();
                userModel = SQLiteService.GetAll<UserModel>("User");

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
            try
            {
                List<UserModel> userModel = new List<UserModel>();
                userModel = SQLiteService.GetAll<UserModel>("User", $"id = {id}");

                if(userModel != null && userModel.Count > 0)
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

        
        [HttpPost]
        public IActionResult CreateUser(
            [FromBody]UserCreateDTO userCreateDTO
            )
        {
            if(SQLiteService.Write<UserCreateDTO>("User", userCreateDTO))
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }            
        }
    }
}
