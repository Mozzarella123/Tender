using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TenderApp.Models;
using TenderApp.Models.BusinessModels;
using TenderApp.Services;

namespace TenderApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IRepository
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

        public void SaveSubGroup(SubGroup group)
        {
            if (group.SubGroupId != -1)
                SubGroups.Add(group);
            else
            {
                var temp = SubGroups.FirstOrDefault(s => s.SubGroupId == group.SubGroupId);
                if (temp != null)
                {
                    temp = group;
                }
                else
                    SubGroups.Add(group);
            }
            SaveChanges();
        }

        public void DeleteSubGroup(SubGroup group)
        {
            if (group != null)//Чтобы ничего не сломалось, необходимо проверять чтобы обьект не был null
            {
                SubGroups.Remove(group);
                SaveChanges();
            }
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<User_Meta> User_Meta { get; set; }
        public DbSet<Post_Meta> Post_Meta { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubGroup> SubGroups { get; set; }
        public DbSet<Sub> Subs { get; set; }
        public IEnumerable<Comment> Comments { get { return Posts.OfType<Comment>().AsEnumerable(); } }
        public IEnumerable<Review> Reviews { get { return Posts.OfType<Review>().AsEnumerable(); } }
        public IEnumerable<Application> Applications { get { return Posts.OfType<Application>().AsEnumerable(); } }
        public IEnumerable<Tender> Tenders { get { return Posts.OfType<Tender>().AsEnumerable(); } }
        public IEnumerable<Offer> Offers { get { return Posts.OfType<Offer>().AsEnumerable(); } }

        IEnumerable<SubGroup> IRepository.SubGroups
        {
            get { if (SubGroups == null)
                    return new List<SubGroup>();
                else
                    return SubGroups.AsEnumerable();
            }
        }
    }
}
