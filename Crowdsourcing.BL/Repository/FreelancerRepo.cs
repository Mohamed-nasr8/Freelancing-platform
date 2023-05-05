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
    public class FreelancerRepo : IRepository<Freelancer>
    {
        private readonly CrowdsourcingContext _context;
  
        public FreelancerRepo(CrowdsourcingContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Freelancer freelancer)
        {
            // Add the Education and Experience objects to the Freelancer's collections
            if (freelancer.Educations != null && freelancer.Educations.Any())
            {
                foreach (var education in freelancer.Educations)
                {
                    _context.Educations.Add(education);
                }
            }

            if (freelancer.Expereinces != null && freelancer.Expereinces.Any())
            {
                foreach (var experience in freelancer.Expereinces)
                {
                    _context.Expereinces.Add(experience);
                }
            }

            if (freelancer.Languages != null && freelancer.Languages.Any())
            {
                foreach (var language in freelancer.Languages)
                {
                    _context.Languages.Add(language);
                }
            }

            await _context.Freelancers.AddAsync(freelancer);
            await _context.SaveChangesAsync();
        }
        public Task<IEnumerable<Freelancer>> FindAsync(Expression<Func<Freelancer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Freelancer>> GetAllAsync()
        {
           return await _context.Freelancers.ToListAsync();
        }

        public async Task<Freelancer> GetAsync(int id)
        {
            return await _context.Freelancers.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            var Remove = await _context.Freelancers.FindAsync(id);
            _context.Freelancers.Remove(Remove);
            _context.SaveChanges();
        }

        public Task<Freelancer> UpdateAsync(Freelancer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return  Task.FromResult(entity);




        }

        public Task<IEnumerable<Freelancer>> UpdateRangeAsync(IEnumerable<Freelancer> entities)
        {
            throw new NotImplementedException();
        }
    }
}
