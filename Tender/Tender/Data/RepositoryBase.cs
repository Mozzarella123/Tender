using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApp.Services;

namespace TenderApp.Data
{
    public class RepositoryBase<T> : IRepository<T>
    {
        ApplicationDbContext context;
        public RepositoryBase(ApplicationDbContext c)
        {
            context = c;
            collection = (ICollection<T>)(context.GetType().GetProperty(typeof(T).Name).GetValue(context, null));//ДОГОВОР: коллекция в контексте должна иметь тоже название, что и имя класса.
            if (collection == null)
                throw (new ArgumentException("Контекст базы данных не содержит коллекции для данного типа данных"));
            _Delete = (T obj) => { collection.Remove(obj); context.Save(); };
            _Create = (T obj) => { collection.Add(obj); context.Save(); };
            _Update = (T obj) => {
                T temp=collection.FirstOrDefault(t=>GetItemId(t)==GetItemId(obj));
                if (temp == null)
                    Create(obj);
                else
                    temp = obj;
                context.Save();
            };
        }
        int GetItemId(T obj)
        {
            int? ret = (int?)obj.GetType().GetProperty(typeof(T).Name + "Id").GetValue(obj,null);
            if (ret == null)
                ret = (int?)obj.GetType().GetProperty("Id").GetValue(obj, null);
            return (int)ret;
        }
        public action<T> _Delete { get; set; }
        public action<T> _Create { get; set; }
        public action<T> _Update { get; set; }
        public void Create(T obj)
        {
            _Create.Invoke(obj);
        }
        public void Delete(T obj)
        {
            _Delete.Invoke(obj);
        }
        public void Update(T obj)
        {
            _Update.Invoke(obj);
        }
        public ICollection<T> collection { get; set; }
    }
}
