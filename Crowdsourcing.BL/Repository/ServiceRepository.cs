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
                .ThenInclude(s=>s.Freelancer).ThenInclude(u => u.User)
                .SingleOrDefault(s=>s.Id==id);
            return result;
        }

        public async Task<IEnumerable<Service>> GetAllAsyncEnum()
        {
            return await _context.Services
                .Include(s => s.ServiceSkills)
                .Include(s=>s.Proposals)
                .ThenInclude(s=>s.Freelancer).ThenInclude(u => u.User)
                .ToListAsync();

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

            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();

                // remove the associated client from the database
                //var client = await _context.Clients.FindAsync(service.ClientId);
                //var payType = await _context.PaymentTypes.FindAsync(service.PaymentTypeId);
                //var skill = await _context.Skills.FindAsync(service.SkillId);
                
                //if (skill != null)
                //{
                //    _context.Skills.Remove(skill);
                //    await _context.SaveChangesAsync();
                //}
                
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
        //public static async void MapToUpdateEntity(ServiceVM viewModel, Service entity)
        //{
        //   // entity.Id = viewModel.Id;
        //    entity.Title = viewModel.Title;
        //    entity.Location = viewModel.Location;
        //    entity.Description = viewModel.Description;
        //    entity.Postedtime = viewModel.Postedtime;
        //    entity.N_of_people= viewModel.N_of_people;
        //    entity.Payment_amount = viewModel.Payment_amount;
        //    entity.Status = (Service.ServiceStatus)viewModel.Status;
        //    entity.Type = (Service.ServiceType)viewModel.Type;
           
        //}

        public Task<IEnumerable<Service>> UpdateRangeAsync(IEnumerable<Service> entities)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateConnectedAccount(int freelancerId)
        {
            throw new NotImplementedException();
        }
    }
}
