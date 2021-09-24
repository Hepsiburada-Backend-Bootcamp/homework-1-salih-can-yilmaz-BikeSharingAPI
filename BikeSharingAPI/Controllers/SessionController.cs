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
        private readonly ISQLiteService SQLiteService;

        public SessionController(ILogService logService, ISQLiteService sQLiteService)
        {
            this.LogService = logService;
            this.SQLiteService = sQLiteService;
        }

        /// <summary>
        /// Tum sessionlarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetSessionList()
        {
            return Ok();
        }

        /// <summary>
        /// Id'si verilen sessioni doner.
        /// </summary>
        /// <param name="id">Kullanici id'si</param>
        /// <returns>Eger bulursa, session bilgileri json formatinda.</returns>
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetSession([FromRoute] int id)
        {
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionCreateDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateSession(
            [FromBody] SessionCreateDTO sessionCreateDTO
            )
        {
            if (SQLiteService.Write<SessionCreateDTO>("User", sessionCreateDTO))
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
            return NoContent();
        }

        /// <summary>
        /// Id'si verilen Session icin veritabanindan silme islemi yapar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSession([FromRoute] int id)
        {
            return Ok();
        }
    }
}
