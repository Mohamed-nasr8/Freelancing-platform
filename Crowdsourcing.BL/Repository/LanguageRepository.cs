using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.ViewModels;
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
    public class LanguageRepository : IRepository<Language>
    {
        private readonly CrowdsourcingContext _context;

        public LanguageRepository(CrowdsourcingContext? context)
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

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<IEnumerable<Language>> GetAllAsyncEnum(int id)
        {
            return await _context.Languages
           .Where(l => l.FreelancerId == id)
           .ToListAsync();
        }

        public async Task<Language> GetAsync(int id)
        {
         return await _context.Languages.FindAsync(id);
            


        }

        public Task<Language> GetAsyncTest(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Language> UpdateAsync(Language entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Language>> UpdateRangeAsync(IEnumerable<Language> entities)
        {
            throw new NotImplementedException();
        }
    }
}
