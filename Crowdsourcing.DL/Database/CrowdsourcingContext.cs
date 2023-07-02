using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crowdsourcing.DL.Database
{
    public class CrowdsourcingContext: IdentityDbContext<ApplicationUser>
    {
        public CrowdsourcingContext(DbContextOptions<CrowdsourcingContext> options):base(options)
        {

        }
        

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceSkills> ServiceSkills { get; set; }
        public DbSet<FreelancerService> FreelancerServices { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Expereince> Expereinces { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<FreelancerSkill> FreelancerSkills { get; set; }

        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            modelBuilder.Entity<Freelancer>()
             .HasMany<Notification>(n => n.Notifications)
             .WithOne(f => f.Freelancer)
             .HasForeignKey(f => f.FreelancerId)
             .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);


    }



















    }
}
