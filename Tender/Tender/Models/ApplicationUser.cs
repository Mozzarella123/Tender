using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TenderApp.Models.BusinessModels;

namespace TenderApp.Models
{
    // Create profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Attachment> Attachments { get; set; }
    }
}
