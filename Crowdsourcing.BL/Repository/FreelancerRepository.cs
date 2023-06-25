using Crowdsourcing.BL.Interface;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Repository
{
    public class FreelancerRepository : IRepository<Freelancer>
    {
        private readonly CrowdsourcingContext _context;
        private readonly IHttpContextAccessor _httpAccessor;

        public FreelancerRepository(CrowdsourcingContext context , IHttpContextAccessor httpAccessor)
        {
            _context = context;
            _httpAccessor = httpAccessor;
        }

        public async Task AddAsync(Freelancer freelancer)
        {

            await _context.Freelancers.AddAsync(freelancer);
            await _context.SaveChangesAsync();
        }
        public Task<IEnumerable<Freelancer>> FindAsync(Expression<Func<Freelancer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Freelancer>> GetAllAsyncEnum()
        {
            return await _context.Freelancers
                .Include(f=>f.Languages)
                .Include(f=>f.Educations)
                .Include(f=>f.Expereinces)
                .Include(f => f.FreelancerServices)
                .Include(f => f.Proposals)
                .ToListAsync();
        }

        public async Task<IEnumerable<Education>> GetAllAsyncEducation(int id)
        {
            return await _context.Educations
              .Where(edu => edu.FreelancerId == id)
              .ToListAsync();
        }

        //public Task<IEnumerable<Freelancer>> GetAllAsyncEnum()
        //{
        //    throw new NotImplementedException();
        //}

        public Task<IEnumerable<Freelancer>> GetAllAsyncEnum(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Freelancer> GetAsync(int id)
        {
            return await _context.Freelancers
              .Include(f => f.Languages)
              .Include(f => f.Educations)
              .Include(f => f.Expereinces)
              .Include(f => f.FreelancerSkills)
              .Include(f => f.FreelancerServices)
              .Include(f => f.Proposals)
              .SingleOrDefaultAsync(f => f.Id == id);
        }




        public async Task RemoveAsync(int id)
        {
            var freelancer = await _context.Freelancers.FindAsync(id);

            if (freelancer != null)
            {
               _context.Freelancers.Remove(freelancer);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Freelancer with ID {id} not found");
            }
        }


        public Task<Freelancer> UpdateAsync(Freelancer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(entity);


        }

        public Task<IEnumerable<Freelancer>> UpdateRangeAsync(IEnumerable<Freelancer> entities)
        {
            throw new NotImplementedException();
        }
    }
}
