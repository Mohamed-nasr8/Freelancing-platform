using Crowdsourcing.BL.Interface;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Repository
{
    public class langrep : IRepository<Language>
    {
        private readonly CrowdsourcingContext _context;

        public langrep(CrowdsourcingContext context)
        {
            _context = context;
        }

        public Task AddAsync(Language entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Language>> FindAsync(Expression<Func<Language, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Language>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Language> GetAsync(int id)
        {
            return await _context.Languages.FindAsync(id);
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Language> UpdateAsync(Language entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(entity);




        }

        public async Task<IEnumerable<Language>> UpdateRangeAsync(IEnumerable<Language> entities)
        {
            _context.Languages.UpdateRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

    }
}
