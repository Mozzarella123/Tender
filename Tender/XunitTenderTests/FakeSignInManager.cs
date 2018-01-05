using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TenderApp.Models;
using Moq;

namespace XunitTenderTests
{
    public class FakeSignInManager : SignInManager<ApplicationUser>
    {
        public FakeSignInManager()
           : base(new Mock<FakeUserManager>().Object,
                 new HttpContextAccessor(),
                 new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
                 new Mock<IOptions<IdentityOptions>>().Object,
                 new Mock<ILogger<SignInManager<ApplicationUser>>>().Object,
                 new Mock<IAuthenticationSchemeProvider>().Object)
        { }
    }
}
