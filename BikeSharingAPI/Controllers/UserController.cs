using BikeSharingAPI.Models;
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
        private readonly ISQLiteService SQLiteService;
        public UserController(ISQLiteService sQLiteService)
        {
            this.SQLiteService = sQLiteService;
        }
        /// <summary>
        /// Tum kullanicilarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetUserList()
        {
            return Ok(SQLiteService.GetAll("User"));
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
                return Ok(SQLiteService.GetAll("User"));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
