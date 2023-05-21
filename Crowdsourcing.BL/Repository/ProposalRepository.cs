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

        public Task<IEnumerable<Proposal>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Proposal>> GetAllAsyncEnum(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Proposal> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
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
