using RepositryPattern.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.Core.Interfaces
{
    public interface IBaseRepositry<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetTheWhole(string[] includes = null);

        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindALL(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindALL(Expression<Func<T, bool>> criteria, int take, int skip);
        IEnumerable<T> FindALL(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);


        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        T Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Attach(T entity);
        int Count();
        int Count(Expression<Func<T, bool>> criteria);
    }
}
