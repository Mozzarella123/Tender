using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TenderApp.Models;
using TenderApp.Models.BusinessModels;

namespace TenderApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Post> Posts { get; }
        public DbSet<Attachment> Attachments { get;  }
        public DbSet<User_Meta> User_Meta { get; }
        public DbSet<Post_Meta> Post_Meta { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<SubGroup> SubGroups { get; }
        public DbSet<Sub> Subs { get; }
        public IEnumerable<Comment> Comments { get { return Posts.OfType<Comment>().AsEnumerable(); } }
        public IEnumerable<Review> Reviews { get { return Posts.OfType<Review>().AsEnumerable(); } }
        public IEnumerable<Application> Applications { get { return Posts.OfType<Application>().AsEnumerable(); } }
        public IEnumerable<Tender> Tenders { get { return Posts.OfType<Tender>().AsEnumerable(); } }
        public IEnumerable<Offer> Offers { get { return Posts.OfType<Offer>().AsEnumerable(); } }

    }
}
