using System.Linq.Expressions;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Crowdsourcing.BL.Repository
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
            var result = await _context.Services.FindAsync(id);
            return result;
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
            await _context.SaveChangesAsync();
        }

        

        public async Task UpdateAsync(int id)
        {
            var service = await _context.Services.FindAsync(id);
            var result = _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
        
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        
        }

        public Task<Service> UpdateAsync(Service entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Service>> UpdateRangeAsync(IEnumerable<Service> entities)
        {
            throw new NotImplementedException();
        }
    }
}
