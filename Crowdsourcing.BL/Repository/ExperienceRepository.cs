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
    public class ExperienceRepository : IRepository<Expereince>
    {
        private readonly CrowdsourcingContext _context;

        public ExperienceRepository(CrowdsourcingContext context)
        {
            _context = context;
        }

        public Task AddAsync(Expereince entity)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateConnectedAccount(int freelancerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Expereince>> FindAsync(Expression<Func<Expereince, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Expereince>> GetAllAsyncEnum()
        {
            return await _context.Expereinces.ToListAsync();
        }

        public async Task<IEnumerable<Expereince>> GetAllAsyncEnum(int id)
        {
            return await _context.Expereinces
                .Where(ex => ex.FreelancerId == id)
                .ToListAsync();
        }

        public Task<Expereince> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Expereince> UpdateAsync(Expereince entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Expereince>> UpdateRangeAsync(IEnumerable<Expereince> entities)
        {
            throw new NotImplementedException();
        }
    }
}
