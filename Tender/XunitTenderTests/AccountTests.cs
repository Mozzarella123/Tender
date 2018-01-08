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
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TenderApp.Data;
using System.Threading;

namespace XunitTenderTests
{
    public class AccountTests : IClassFixture<TestFixture<Startup>>
    {
        public class UserControllerTests : IClassFixture<TestFixture<Startup>>
        {

            private AccountController Controller { get; }

            public UserControllerTests(TestFixture<Startup> fixture)
            {
                var config = new ConfigurationBuilder().Build();
                var services = new ServiceCollection()
                    .AddSingleton<IConfiguration>(config)
                    .AddTransient<IRepository, ApplicationDbContext>();
                services.AddIdentity<ApplicationUser, IdentityRole>();
                services.AddLogging();
                var store = new Mock<IUserStore<ApplicationUser>>();
                var user = new ApplicationUser { UserName = "Foo" };
                store.Setup(s => s.CreateAsync(user, CancellationToken.None)).ReturnsAsync(IdentityResult.Success).Verifiable();
                store.Setup(s => s.GetUserNameAsync(user, CancellationToken.None)).Returns(Task.FromResult(user.UserName)).Verifiable();
                store.Setup(s => s.SetNormalizedUserNameAsync(user, user.UserName.ToUpperInvariant(), CancellationToken.None)).Returns(Task.FromResult(0)).Verifiable();
                var usermanager = MockHelpers.TestUserManager(store.Object);
                var context = new DefaultHttpContext();
                var signinmanager = SetupSignInManager(usermanager, context);
                var emailsender = new Mock<IEmailSender>().Object;
                var logger = new Mock<ILogger<AccountController>>().Object;
                usermanager.CreateAsync(user, "12345qwe");
                var controller = new AccountController(usermanager, signinmanager, emailsender, logger);
                Controller = controller;
            }

            [Fact]
            public async Task LoginbyUserName()
            {
                //arrange
              

                var model = new LoginViewModel() { UserName = "test", Password = "12345qwe" };
                
                //act
                var result = await Controller.Login(model) as RedirectToRouteResult;

                //assert
                Assert.NotNull(result);
            }
            [Theory]
            [InlineData("test@test.it", "Ciao.Ciao")]
            public async Task RegisterTest(string email, string password)
            {
                //arrange
                var ApplicationUser = new RegisterViewModel() { Email = email, Password = password, ConfirmPassword = password };
                //act
                IActionResult createdUser = await Controller.Register(ApplicationUser, "/");
                //assert
                Assert.NotNull(createdUser);

            }
            private static Mock<UserManager<ApplicationUser>> SetupUserManager(ApplicationUser user)
            {
                var manager = MockHelpers.MockUserManager<ApplicationUser>();
                manager.Setup(m => m.FindByNameAsync(user.UserName)).ReturnsAsync(user);
                manager.Setup(m => m.FindByIdAsync(user.Id)).ReturnsAsync(user);
                manager.Setup(m => m.GetUserIdAsync(user)).ReturnsAsync(user.Id.ToString());
                manager.Setup(m => m.GetUserNameAsync(user)).ReturnsAsync(user.UserName);
                return manager;
            }
            private static SignInManager<ApplicationUser> SetupSignInManager(UserManager<ApplicationUser> manager, HttpContext context, StringBuilder logStore = null, IdentityOptions identityOptions = null)
            {
                var contextAccessor = new Mock<IHttpContextAccessor>();
                contextAccessor.Setup(a => a.HttpContext).Returns(context);
                var roleManager = MockHelpers.MockRoleManager<IdentityRole>();
                identityOptions = identityOptions ?? new IdentityOptions();
                var options = new Mock<IOptions<IdentityOptions>>();
                options.Setup(a => a.Value).Returns(identityOptions);
                var claimsFactory = new UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>(manager, roleManager.Object, options.Object);
                var sm = new SignInManager<ApplicationUser>(manager, contextAccessor.Object, claimsFactory, options.Object, null, new Mock<IAuthenticationSchemeProvider>().Object);
                sm.Logger = MockHelpers.MockILogger<SignInManager<ApplicationUser>>(logStore ?? new StringBuilder()).Object;
                return sm;
            }
        }
    }
}
