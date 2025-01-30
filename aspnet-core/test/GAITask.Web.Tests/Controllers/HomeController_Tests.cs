﻿using System.Threading.Tasks;
using GAITask.Models.TokenAuth;
using GAITask.Web.Controllers;
using Shouldly;
using Xunit;

namespace GAITask.Web.Tests.Controllers
{
    public class HomeController_Tests: GAITaskWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}