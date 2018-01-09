using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Services;

namespace TenderApp.Data
{
    public class SubRepository<T> : ISubRepository<T>
    {
        public SubRepository(IRepository context)
        {
            this.context = context;
            collection = (IEnumerable<T>)(context.GetType().GetProperty(typeof(T).Name).GetValue(context,null));
            Delete = (T entity) => { };
        }
        public action<T> Delete { get; set; }
        public action<T> Create { get; set; }
        public action<T> Update { get; set; }
        public IEnumerable<T> collection { get; set; }
        IRepository context;
    }
}
