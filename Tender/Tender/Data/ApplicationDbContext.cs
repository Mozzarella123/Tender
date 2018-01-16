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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>,IEFContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext() : base()
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
                SubGroup.Add(group);
            else
            {
                var temp = SubGroup.FirstOrDefault(s => s.SubGroupId == group.SubGroupId);
                if (temp != null)
                {
                    temp = group;
                }
                else
                    SubGroup.Add(group);
            }
            SaveChanges();
        }

        public void DeleteSubGroup(SubGroup group)
        {
            if (group != null)//Чтобы ничего не сломалось, необходимо проверять чтобы обьект не был null
            {
                SubGroup.Remove(group);
                SaveChanges();
            }
        }
        public DbSet<Post> Post { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<User_Meta> User_Meta { get; set; }
        public DbSet<Post_Meta> Post_Meta { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubGroup> SubGroup { get; set; }
        public DbSet<Sub> Sub { get; set; }
        public IEnumerable<Comment> Comment { get { return Post.OfType<Comment>().AsEnumerable(); } }
        public IEnumerable<Review> Review { get { return Post.OfType<Review>().AsEnumerable(); } }
        public IEnumerable<Application> Application { get { return Post.OfType<Application>().AsEnumerable(); } }
        public IEnumerable<Tender> Tender { get { return Post.OfType<Tender>().AsEnumerable(); } }
        public IEnumerable<Offer> Offer { get { return Post.OfType<Offer>().AsEnumerable(); } }

        IEnumerable<Post> IContext.Post { get => Post; }
        IEnumerable<Attachment> IContext.Attachment { get => Attachment; }
        IEnumerable<User_Meta> IContext.User_Meta { get => User_Meta; }
        IEnumerable<Post_Meta> IContext.Post_Meta { get => Post_Meta; }
        IEnumerable<Category> IContext.Category { get => Category; }
        IEnumerable<SubGroup> IContext.SubGroup { get => SubGroup; }
        IEnumerable<Sub> IContext.Sub { get => Sub; }

        public void Save()
        {
            SaveChanges();
        }

        //IEnumerable<SubGroup> IRepository.SubGroups
        //{
        //    get { if (SubGroup == null)
        //            return new List<SubGroup>();
        //        else
        //            return SubGroup.AsEnumerable();
        //    }
        //}
    }
}
