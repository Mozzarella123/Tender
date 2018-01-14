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
        DbSet<Post> Post { get; set; }
        DbSet<Attachment> Attachment { get; set; }
        DbSet<User_Meta> User_Meta { get; set; }
        DbSet<Post_Meta> Post_Meta { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<SubGroup> SubGroup { get; set; }
        DbSet<Sub> Sub { get; set; }
        IEnumerable<Comment> Comment { get; }
        IEnumerable<Review> Review { get; }
        IEnumerable<Application> Application { get; }
        IEnumerable<Tender> Tender { get; }
        IEnumerable<Offer> Offer { get; }
        void SaveSubGroup(SubGroup group);
        void DeleteSubGroup(SubGroup group);
        void Save();
    }

    public delegate void action<T>(T entity);
    public interface IRepository<T> where T :class
    {
        void Delete(T obj);
        void Create(T obj);
        void Update(T obj);
        ICollection<T> collection { get; set; }
    }
}
