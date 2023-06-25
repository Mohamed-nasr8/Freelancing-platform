using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Models;
using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Repository
{
    public class ProposalRepository : IRepository<Proposal>
    {
        private readonly CrowdsourcingContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public ProposalRepository(CrowdsourcingContext context , UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
        }

        public async Task AddAsync(Proposal prop)
        {
            await _context.AddAsync(prop);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Proposal>> FindAsync(Expression<Func<Proposal, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Proposal>> GetAllAsyncEnum()
        {
            return await _context.Proposals
            .Include(p => p.Freelancer)
            .Include(p => p.Service)
            .ToListAsync();
        }

        public async Task<IEnumerable<Proposal>> GetAllAsyncEnum(int id)
        {
            return (IEnumerable<Proposal>)await _context.Proposals
                .Include(p => p.ServiceId)
                .Include(p => p.PaymentTypeId)
                .Include(p => p.FreelancerId)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Proposal> GetAsync(int id)
        {
            return await _context.Proposals
            .Include(p => p.Freelancer)
            .Include(p => p.Service)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var proposal = await _context.Proposals.FindAsync(id);
            _context.Remove(proposal);
            _context.SaveChanges();
              
        }

        public Task<Proposal> UpdateAsync(Proposal entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<IEnumerable<Proposal>> UpdateRangeAsync(IEnumerable<Proposal> entities)
        {
            throw new NotImplementedException();
        }
    }

      
    }
