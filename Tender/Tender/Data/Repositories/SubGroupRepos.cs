using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;

namespace TenderApp.Data.Repositories
{
    public class SubGroupRepos:RepositoryBase<SubGroup>
    {
        public SubGroupRepos(ApplicationDbContext c,ref List<SubGroup> list) : base(c,ref list)
        {

        }
    }
}
