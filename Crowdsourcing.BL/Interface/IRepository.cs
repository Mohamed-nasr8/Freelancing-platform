using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Interface
{
    public interface IRepository
    {
        public interface IRepository<TEntity> where TEntity : class
        {
            TEntity Get(int id);
            IEnumerable<TEntity> GetAll();
            IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
            void Add(TEntity entity);
            void Remove(TEntity entity);
            void Update(TEntity entity);
            int Count(Expression<Func<TEntity, bool>> predicate = null);
        }




    }
}
