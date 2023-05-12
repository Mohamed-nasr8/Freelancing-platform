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
    public class EducationRepository:IRepository<Education>
    {
        private readonly CrowdsourcingContext _context;

        public EducationRepository(CrowdsourcingContext context)
        {
            _context = context;
        }

        public Task AddAsync(Education entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Education>> FindAsync(Expression<Func<Education, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Education>> GetAllAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<IEnumerable<Education>> GetAllAsyncEnum(int id)
        {
            return await _context.Educations
             .Where(edu => edu.FreelancerId == id)
             .ToListAsync();
        }

        public Task<Education> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Education> UpdateAsync(Education entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Education>> UpdateRangeAsync(IEnumerable<Education> entities)
        {
            throw new NotImplementedException();
        }
    }
}
