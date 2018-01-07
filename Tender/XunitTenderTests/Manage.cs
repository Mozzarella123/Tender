using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models;
using TenderApp.Models.AccountViewModels;
using TenderApp.Services;
using TenderApp.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TenderApp;
using Xunit;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Text.Encodings.Web;

namespace XunitTenderTests
{
    public class ManageTests : IClassFixture<TestFixture<Startup>>
    {
        public class UserControllerTests : IClassFixture<TestFixture<Startup>>
        {

            private ManageController Controller { get; }
            FakeSignInManager fakeSignInManager;
            FakeUserManager fakeUserManager;

            public UserControllerTests(TestFixture<Startup> fixture)
            {

                var users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    UserName = "Test",
                    Id = Guid.NewGuid().ToString(),
                    Email = "test@test.it",
                }

            }.AsQueryable();

                var fakeUserManager = new Mock<FakeUserManager>();

                fakeUserManager.Setup(x => x.Users)
                    .Returns(users);

                fakeUserManager.Setup(x => x.DeleteAsync(It.IsAny<ApplicationUser>()))
                 .ReturnsAsync(IdentityResult.Success);
                fakeUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
                fakeUserManager.Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>()))
              .ReturnsAsync(IdentityResult.Success);

                var fakeSigninManager = new FakeSignInManager();

                var passwordhasher = (IPasswordHasher<ApplicationUser>)fixture.Server.Host.Services.GetService(typeof(IPasswordHasher<ApplicationUser>));


                var uservalidator = new Mock<IUserValidator<ApplicationUser>>();
                uservalidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<ApplicationUser>>(), It.IsAny<ApplicationUser>()))
                 .ReturnsAsync(IdentityResult.Success);
                var passwordvalidator = new Mock<IPasswordValidator<ApplicationUser>>();
                passwordvalidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<ApplicationUser>>(), It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                 .ReturnsAsync(IdentityResult.Success);

                var signInManager = new Mock<FakeSignInManager>();

                signInManager.Setup(
                        x => x.PasswordSignInAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                    .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

                EmailSender emailSender = new Mock<EmailSender>().Object;
            
                ILogger<ManageController> logger = new Mock<ILogger<ManageController>>().Object;
                UrlEncoder encoder = new Mock<UrlEncoder>().Object;

                //SERVICES CONFIGURATIONS
                fakeSignInManager = fakeSigninManager;
                this.fakeUserManager = fakeUserManager.Object;

                Controller = new ManageController(fakeUserManager.Object, fakeSigninManager, emailSender, logger,encoder);
                Controller.Url = new Mock<UrlHelper>().Object;
                
            }
            [Fact]
            public async Task<IActionResult> Index()
            {
                //arrange
                
                //act

                //assert
            }


        }
    }
}
