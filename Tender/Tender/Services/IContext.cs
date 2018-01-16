using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;

namespace TenderApp.Services
{
    public interface IContext
    {
        IEnumerable<Post> Post { get; }
        IEnumerable<Attachment> Attachment { get; }
        IEnumerable<User_Meta> User_Meta { get; }
        IEnumerable<Post_Meta> Post_Meta { get; }
        IEnumerable<Category> Category { get; }
        IEnumerable<SubGroup> SubGroup { get; }
        IEnumerable<Sub> Sub { get; }
        void Save();
    }
}
