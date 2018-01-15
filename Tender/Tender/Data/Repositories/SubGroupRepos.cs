using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;
using TenderApp.Services;

namespace TenderApp.Data.Repositories
{
    public class SubGroupRepos:RepositoryBase<SubGroup>
    {
        public SubGroupRepos(IEFContext c) : base(c,c.SubGroup)
        {

        }
    }
}
