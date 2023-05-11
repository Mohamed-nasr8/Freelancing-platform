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
    public class RatingRepository : IRepository<Rating>
    {
        private readonly CrowdsourcingContext _context;

        public RatingRepository(CrowdsourcingContext context)
        {
            _context = context;
        }

        public Task AddAsync(Rating entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rating>> FindAsync(Expression<Func<Rating, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rating>> GetAllAsync()
        {
            return await _context.Ratings.ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetAllAsyncEnum(int id)
        {
            return await _context.Ratings
            .Where(r=> r.FreelancerId == id)
            .ToListAsync();
        }

        public Task<Rating> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Rating> UpdateAsync(Rating entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rating>> UpdateRangeAsync(IEnumerable<Rating> entities)
        {
            throw new NotImplementedException();
        }
    }
}
