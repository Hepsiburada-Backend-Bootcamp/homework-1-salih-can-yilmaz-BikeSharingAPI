using BikeSharingAPI.Enums;
using BikeSharingAPI.Models.DTOs.Users;
using BikeSharingAPI.Services.IServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSharingAPI.Test
{
    public class UserServiceGetUserTest
    {
        public void GetUserTest()
        {
            var mock = new Mock<IUserService>();

            mock.Setup(service => service.GetUser(It.IsAny<int>())).Returns(GetMockServiceUser());
        }

        public UserReadDTO GetMockServiceUser()
        {
            return new UserReadDTO
            {
                Id = 1,
                Balance = 50.2,
                BirthDate = DateTime.Now.AddYears(-25),
                EMail = "asd@gmail.com",
                DateJoined = DateTime.Now.AddDays(-15),
                Gender = EnumGender.M,
                Name = "Testtt",
                PhoneNumber = "123456789",
                Surname = "Testson"
            };
        }
    }
}
