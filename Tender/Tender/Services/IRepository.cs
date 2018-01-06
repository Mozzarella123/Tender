using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;
using Microsoft.EntityFrameworkCore;


namespace TenderApp.Services
{
    public interface IRepository
    {
        DbSet<Post> Posts { get; }
        DbSet<Attachment> Attachments { get; }
        DbSet<User_Meta> User_Meta { get; }
        DbSet<Post_Meta> Post_Meta { get; }
        DbSet<Category> Categories { get; }
        DbSet<SubGroup> SubGroups { get; }
        DbSet<Sub> Subs { get; }
        IEnumerable<Comment> Comments { get; }
        IEnumerable<Review> Reviews { get; }
        IEnumerable<Application> Applications { get; }
        IEnumerable<Tender> Tenders { get; }
        IEnumerable<Offer> Offers { get; }
    }
}
