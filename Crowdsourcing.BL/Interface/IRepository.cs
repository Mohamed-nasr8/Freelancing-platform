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
            Task<TEntity> GetAsync(int id);
            Task<IEnumerable<TEntity>> GetAllAsync();
            Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
            Task AddAsync(TEntity entity);
            Task RemoveAsync(TEntity entity);
            Task UpdateAsync(TEntity entity);
        }




    }
}
