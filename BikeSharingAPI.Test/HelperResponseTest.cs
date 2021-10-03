using BikeSharingAPI.Enums;
using BikeSharingAPI.Helpers;
using BikeSharingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;


namespace BikeSharingAPI.Test
{
    public class HelperResponseTest
    {
        [Theory]
        [MemberData(nameof(JsonDataProvider))]
        public void JsonResultTest(string expected, object data)
        {
            var result = HelperResponse.GenerateResponse(
                    EnumResponseFormat.JSON,
                    HttpStatusCode.OK,
                    data
                );

            var contentResult = result as ContentResult;

            Assert.Equal(expected, contentResult.Content);
        }

        public static IEnumerable<object[]> JsonDataProvider =>
           new List<object[]>
           {
                new object[] {"{\"Id\":1,\"Name\":\"TestName\"}", new { Id = 1, Name = "TestName" }},
                new object[] { "[1,2,3,4,5]", new object[]{ 1,2,3,4,5} },
                new object[] { "[\"elma\",\"armut\",\"mandalina\"]", new List<object> { "elma", "armut", "mandalina"} },
                new object[] { "{\"ErrorMessage\":\"There is an error\"}", new ErrorModel { ErrorMessage = "There is an error"} },
                new object[] { "[{\"Id\":1,\"Name\":\"TestName1\"},{\"Id\":2,\"Name\":\"TestName2\"},{\"Id\":3,\"Name\":\"TestName3\"}]",
                        new List<object> { new { Id = 1, Name = "TestName1" }, new { Id = 2, Name = "TestName2" }, new { Id = 3, Name = "TestName3" } } }
           };
    }
}
