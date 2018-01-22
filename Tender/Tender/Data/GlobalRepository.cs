using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;
using TenderApp.Services;

namespace TenderApp.Data
{
    public class GlobalRepository : IRepository
    {
        public GlobalRepository(IContext context,
            IRepository<SubGroup> subGroup,IRepository<Sub> subs)
        {
            Context = context;
            SubGroup = subGroup;
            Sub = subs;
        }
        IContext Context;
        public IRepository<Post> Post { get; set; }
        public IRepository<Attachment> Attachment { get; set; }
        public IRepository<User_Meta> User_Meta { get; set; }
        public IRepository<Post_Meta> Post_Meta { get; set; }
        public IRepository<Category> Category { get; set; }
        public IRepository<SubGroup> SubGroup { get; set; }
        public IRepository<Sub> Sub { get; set; }

        public IEnumerable<Comment> Comment { get { return Post.OfType<Comment>().AsEnumerable(); } }
        public IEnumerable<Review> Review { get { return Post.OfType<Review>().AsEnumerable(); } }
        public IEnumerable<Application> Application { get { return Post.OfType<Application>().AsEnumerable(); } }
        public IEnumerable<Tender> Tender { get { return Post.OfType<Tender>().AsEnumerable(); } }
        public IEnumerable<Offer> Offer { get { return Post.OfType<Offer>().AsEnumerable(); } }
        
        public void Save()
        {
            Context.Save();
        }
    }
}
