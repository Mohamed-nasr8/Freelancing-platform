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
    public class FreelancerServiceRepository : IRepository<FreelancerService>
    {
        private readonly CrowdsourcingContext _context;

        public FreelancerServiceRepository(CrowdsourcingContext context)
        {
            _context = context;
        }

        public Task AddAsync(FreelancerService entity)
        {
            throw new NotImplementedException();
        }

        
        public async Task<IEnumerable<FreelancerService>> GetAllAsyncEnum()
        {
            return await _context.FreelancerServices.ToListAsync();
        }

        public async Task<IEnumerable<FreelancerService>> GetAllAsyncEnum(int id)
        {
            return await _context.FreelancerServices
             .Where(sk => sk.FreelancerId == id)
             .ToListAsync();
        }

        public async Task<FreelancerService> GetAsync(int id)
        {
            return await _context.FreelancerServices.FindAsync(id);
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FreelancerService> UpdateAsync(FreelancerService entity)
        {
            throw new NotImplementedException();
        }

  
    }
}
