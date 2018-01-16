using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Services;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace TenderApp.Data
{
    public class RepositoryBase<T> : IRepository<T>,IEnumerator where T:class
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
            return new ParametrisedEnumerator<T>(collection.OfType<T>());
        }

        int position = -1;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }

        public bool MoveNext()
        {
            if (position < collection.Count() - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        

        public DbSet<T> collection { get; set; }

        public int Count => collection.Count();

        public bool IsReadOnly => false;

        public object Current
        { get
            {
                if (position >= 0)
                    return collection.ElementAt(position);
                else
                    return null;
            }
        }
    }

    public class ParametrisedEnumerator<T> : IEnumerator<T>
    {
        public ParametrisedEnumerator(IEnumerable<T> collection)
        {
            this.collection = collection;
        }

        IEnumerable<T> collection;
        int position = -1;

        public T Current => collection.ElementAt(position);

        object IEnumerator.Current => collection.ElementAt(position);

        public void Dispose()
        {
            collection = null;
        }

        public bool MoveNext()
        {
            if (position < collection.Count() - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
