using Project_Eticaret.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eticaret.CORE.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        void Add(T item);
        void Add(List<T> item);
        void Update(T item);
        void Remove(T item);
        void Remove(Guid id);
        void RemoveAll(Expression<Func<T, bool>> exp);
        T GetByID(Guid id);
        T GetByDefault(Expression<Func<T, bool>> exp);
        List<T> GetActive();
        List<T> GetDefault(Expression<Func<T, bool>> exp);
        List<T> GetAll();
        bool Any(Expression<Func<T, bool>> exp);
        int Save();
    }
}
