using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;

namespace TenderApp.Services
{
    public interface IEFContext:IContext
    {
        DbSet<Post> Post { get; set; }
        DbSet<Attachment> Attachment { get; set; }
        DbSet<User_Meta> User_Meta { get; set; }
        DbSet<Post_Meta> Post_Meta { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<SubGroup> SubGroup { get; set; }
        DbSet<Sub> Sub { get; set; }
        void Save();
    }
}
