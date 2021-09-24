using AutoMapper;
using BikeSharingAPI.Enums;
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
using System.Threading.Tasks;

namespace BikeSharingAPI.Controllers
{
    [Route("api/v1/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogService _LogService;
        private readonly IUserService _UserService;
        private readonly IMapper _Mapper;

        public UserController(ILogService logService, IUserService userService, IMapper mapper)
        {
            this._LogService = logService;
            this._UserService = userService;
            this._Mapper = mapper;
        }

        /// <summary>
        /// Tum kullanicilarin bir listesini doner.
        /// </summary>
        /// <returns>Json formatinda kullanici listesi.</returns>
        [HttpGet]
        public IActionResult GetUserList()
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            try
            {                
                List<User> userModel = _UserService.GetAll();

                if(userModel != null && userModel.Count > 0)
                {
                    List<UserReadDTO> userReadDTOs = _Mapper.Map<List<UserReadDTO>>(userModel);

                    return Ok(userReadDTOs);
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
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);
            try
            {
                User userModel = _UserService.GetById(id);

                if(userModel != null)
                {
                    UserReadDTO userReadDTO = _Mapper.Map<UserReadDTO>(userModel);

                    return Ok(userReadDTO);
                }
                else
                {
                    return NotFound(SharedData.MessageUserNotFound);
                }
            }
            catch (Exception ex)
            {
                _LogService.Log(ex.Message, EnumLogLevel.ERROR);
                
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
            [FromBody] UserCreateDTO userCreateDTO
            )
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            User user = _Mapper.Map<User>(userCreateDTO);

            if (_UserService.Create(user))
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
        public IActionResult PutUser([FromBody] UserUpdateDTO userUpdateDTO)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            User user = _Mapper.Map<User>(userUpdateDTO); 

            if(_UserService.Update(user))
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
        public IActionResult PatchUser([FromBody] UserUpdateDTO userUpdateDTO)
        {
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            User user = _UserService.GetById(userUpdateDTO.Id);
            
            if(user == null)
            {
                return NotFound();
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserUpdateDTO, User>();
                cfg.ForAllPropertyMaps(
                    pm => pm.TypeMap.SourceType == typeof(UserUpdateDTO),
                        (pm, c) => c.MapFrom(new IgnoreNullResolver(), pm.SourceMember.Name));
            });
            
            IMapper iMapper = config.CreateMapper();

            user = iMapper.Map(userUpdateDTO, user);

            if (_UserService.Update(user))
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
            _LogService.Log(SharedData.LogMessageRequestReceived, EnumLogLevel.INFORMATION);

            _UserService.Delete(id);

            return Ok();
        }
    }
}
