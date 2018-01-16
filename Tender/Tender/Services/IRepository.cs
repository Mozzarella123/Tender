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
        IRepository<Post> Post { get; set; }
        IRepository<Attachment> Attachment { get; set; }
        IRepository<User_Meta> User_Meta { get; set; }
        IRepository<Post_Meta> Post_Meta { get; set; }
        IRepository<Category> Category { get; set; }
        IRepository<SubGroup> SubGroup { get; set; }
        IRepository<Sub> Sub { get; set; }
        IEnumerable<Comment> Comment { get; }
        IEnumerable<Review> Review { get; }
        IEnumerable<Application> Application { get; }
        IEnumerable<Tender> Tender { get; }
        IEnumerable<Offer> Offer { get; }
        void Save();
    }
    
    public interface IRepository<T>:ICollection<T>
    {
        void Update(T obj);
    }
}
