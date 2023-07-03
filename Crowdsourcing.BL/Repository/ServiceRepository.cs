using System.Linq.Expressions;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Models;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Crowdsourcing.BL.Repository
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly CrowdsourcingContext _context;

        public ServiceRepository(CrowdsourcingContext context)
        {
            _context = context;
        }
       

        public async Task< Service> GetAsync(int id)
        {
            var result =  _context.Services
                .Include(s => s.ServiceSkills)
                .Include(s => s.Proposals)
                .ThenInclude(s=>s.Freelancer)
                .SingleOrDefault(s=>s.Id==id);
            return result;
        }

        public async Task<IEnumerable<Service>> GetAllAsyncEnum()
        {
            return await _context.Services
                .Include(s => s.ServiceSkills)
                .Include(s=>s.Proposals)
                .ThenInclude(s=>s.Freelancer)
                .ToListAsync();

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

            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();

                
                
            }
        }

        public async Task<Service> UpdateAsync(Service entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Service>> GetAllAsyncEnum(int id)
        {
            return await _context.Services
                .Where(s => s.Id == id)
                .ToListAsync();
        }
       


    }
}
