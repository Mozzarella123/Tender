using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApp.Services
{
    public delegate void action<T>(T entity);
    interface ISubRepository<T>
    {
        action<T> Delete { get; set; }
        action<T> Create { get; set; }
        action<T> Update { get; set; }
        IEnumerable<T> collection { get; set; }
    }
}
