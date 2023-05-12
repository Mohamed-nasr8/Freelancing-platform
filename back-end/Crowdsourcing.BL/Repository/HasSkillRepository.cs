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
    public class HasSkillRepository : IRepository<HasSkill>
    {
        private readonly CrowdsourcingContext _context;

        public HasSkillRepository(CrowdsourcingContext context)
        {
            _context = context;
        }

        public Task AddAsync(HasSkill entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HasSkill>> FindAsync(Expression<Func<HasSkill, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HasSkill>> GetAllAsync()
        {
            return await _context.HasSkills.ToListAsync();
        }

        public async Task<IEnumerable<HasSkill>> GetAllAsyncEnum(int id)
        {
            return await _context.HasSkills
                 .Where(hs => hs.FreelancerId == id)
                 .ToListAsync();
        }

        public Task<HasSkill> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HasSkill> UpdateAsync(HasSkill entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HasSkill>> UpdateRangeAsync(IEnumerable<HasSkill> entities)
        {
            throw new NotImplementedException();
        }
    }
}
