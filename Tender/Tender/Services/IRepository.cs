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

        DbSet<Sub> Subs { get; set; }
        IEnumerable<Comment> Comments { get; }
        IEnumerable<Review> Reviews { get; }
        IEnumerable<Application> Applications { get; }
        IEnumerable<Tender> Tenders { get; }
        IEnumerable<Offer> Offers { get; }
        IEnumerable<SubGroup> SubGroups { get; }
        void SaveSubGroup(SubGroup group);
        void DeleteSubGroup(SubGroup group);
    }
}
