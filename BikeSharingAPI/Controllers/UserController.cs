using BikeSharingAPI.Models;
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
        /// <summary>
        /// Tum kullanicilarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetUserList()
        {
            Dictionary<int, testUserModel> testData = new Dictionary<int, testUserModel>
            {
                [1] = new testUserModel("Ali"),
                [2] = new testUserModel("Veli"),
                [3] = new testUserModel("İsmail")
            };

            return Ok(testData);
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
            Dictionary<int, testUserModel> testData = new Dictionary<int, testUserModel>
            {
                [1] = new testUserModel("Ali"),
                [2] = new testUserModel("Veli"),
                [3] = new testUserModel("İsmail")
            };

            if(testData.TryGetValue(id, out var returnValue))
            {
                return Ok(returnValue);
            }
            else
            {
                return NotFound("User not found!");
            }
        }
    }
}
