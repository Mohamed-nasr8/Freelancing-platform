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

namespace Crowdsourcing.BL.Repo
{
    public class ServiceRep : IRepository<Service>
    {
        private readonly CrowdsourcingContext _context;

        public ServiceRep(CrowdsourcingContext context)
        {
            _context = context;
        }


        public async Task<Service> GetAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _context.Services.ToListAsync();

        }

        public async Task<IEnumerable<Service>> FindAsync(Expression<Func<Service, bool>> predicate)
        {
            return await _context.Services.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(Service entity)
        {
            await _context.Services.AddAsync(entity);
        }

        public async Task RemoveAsync(Service entity)
        {
            _context.Services.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service entity)
        {
            _context.Services.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

