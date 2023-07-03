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
    public class FreelancerSkillRepository : IRepository<FreelancerSkill>
    {
        private readonly CrowdsourcingContext _context;

        public FreelancerSkillRepository(CrowdsourcingContext context)
        {
            _context = context;
        }

        public Task AddAsync(FreelancerSkill entity)
        {
            throw new NotImplementedException();
        }

     
        

        public async Task<IEnumerable<FreelancerSkill>> GetAllAsyncEnum()
        {
            return await _context.FreelancerSkills.ToListAsync();
        }

        public async Task<IEnumerable<FreelancerSkill>> GetAllAsyncEnum(int id)
        {
            return await _context.FreelancerSkills
             .Where(sk => sk.FreelancerId == id)
             .ToListAsync();
        }

        public async Task<FreelancerSkill> GetAsync(int id)
        {
            return await _context.FreelancerSkills.FindAsync(id);
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FreelancerSkill> UpdateAsync(FreelancerSkill entity)
        {
            throw new NotImplementedException();
        }

    }
}
