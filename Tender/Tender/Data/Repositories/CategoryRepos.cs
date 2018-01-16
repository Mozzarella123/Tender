using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Models.BusinessModels;
using TenderApp.Services;

namespace TenderApp.Data.Repositories
{
    public class CategoryRepos : RepositoryBase<Category>
    {
        public CategoryRepos(IEFContext c) : base(c, c.Category)
        {

        }
    }
}
