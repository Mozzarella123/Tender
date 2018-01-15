using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Services;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace TenderApp.Data
{
    public class RepositoryBase<T> : IRepository<T> where T:class
    {
        IContext context;
        public RepositoryBase(IEFContext c,DbSet<T> set)
        {
            context = c;
            this.collection = set;
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
            
        }
        public void Delete(T obj)
        {
            
        }
        public void Update(T obj)
        {
            collection.Update(obj);
            context.Save();
        }

        public void Add(T item)
        {
            collection.Add(item);
            context.Save();
        }

        public void Clear()
        {
            foreach (T elem in collection)
                collection.Remove(elem);
            context.Save();
        }

        public bool Contains(T item)
        {
            return collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            collection.Remove(item);
            context.Save();
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public DbSet<T> collection { get; set; }

        public int Count => collection.Count();

        public bool IsReadOnly => false;
    }
}
