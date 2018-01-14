using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Services;
using System.Collections;

namespace TenderApp.Data
{
    public class RepositoryBase<T> : IRepository<T> where T:class
    {
        ApplicationDbContext context;
        public RepositoryBase(ApplicationDbContext c,ref List<T> AllCollection)
        {
            context = c;
            this.collection = AllCollection;
        }

        int GetItemId(T obj)
        {
            int? ret = (int?)obj.GetType().GetProperty(typeof(T).Name + "Id").GetValue(obj,null);
            if (ret == null)
                ret = (int?)obj.GetType().GetProperty("Id").GetValue(obj, null);
            return (int)ret;
        }
        public void Create(T obj)
        {
            collection.Add(obj);
            context.Save();
        }
        public void Delete(T obj)
        {
            collection.Remove(obj);
            context.Save();
        }
        public void Update(T obj)
        {
            T temp = collection.FirstOrDefault(t => GetItemId(t) == GetItemId(obj));
            if (temp == null)
                Create(obj);
            else
            {
                Delete(temp);
                Create(obj);
            }
            context.Save();
        }
        public ICollection<T> collection { get; set; }
    }
}
