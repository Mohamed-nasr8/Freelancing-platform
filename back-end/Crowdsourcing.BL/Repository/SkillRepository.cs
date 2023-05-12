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
    public class SkillRepository : IRepository<Skill>
    {
        private readonly CrowdsourcingContext _context;

        public SkillRepository(CrowdsourcingContext context)
        {
            _context = context;
        }

        public Task AddAsync(Skill entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Skill>> FindAsync(Expression<Func<Skill, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<IEnumerable<Skill>> GetAllAsyncEnum(int id)
        {
            return await _context.Skills
             .Where(sk => sk.Id == id)
             .ToListAsync();
        }

        public Task<Skill> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Skill> UpdateAsync(Skill entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Skill>> UpdateRangeAsync(IEnumerable<Skill> entities)
        {
            throw new NotImplementedException();
        }
    }
}
