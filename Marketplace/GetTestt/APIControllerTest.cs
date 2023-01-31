using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Runtime.InteropServices;
using Marketplace.Controllers;
using Marketplace.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Xunit.Sdk;

namespace GetTest
{
    public class APIControllerTest
    {
        [Fact]
        public void TestGet()
        {
            //Given
            APIController controller = new APIController();
            UserAccount expected = new UserAccount()
            {
                UserID = 1,
                Userame = "test",
                Email = "test",
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "test",
                Address = "test",
                Password = "test",
                Rank = "Admin"
            };
            //When
            var actualObjectResult = controller.Get(1);
            var okResult = actualObjectResult as OkObjectResult;
            var actualUser = okResult.Value as UserAccount;

            //Then
            Assert.Equal(expected.UserID, actualUser.UserID);
            Assert.Equal(expected.Rank, actualUser.Rank);

        }
    }
}