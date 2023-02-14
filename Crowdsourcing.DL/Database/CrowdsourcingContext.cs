using Crowdsourcing.DL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.DL.Database
{
    public class CrowdsourcingContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=.;database=CrowdsourcingDb;Integrated Security=true");
        }
        // defult value for Notification
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>()
                .Property(e => e.created_at)
                .HasDefaultValueSql("GETDATE()");
    
        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<user_account> user_accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<other_skills> other_skills { get; set; }
        public DbSet<Verification> Verifications { get; set; }
        public DbSet<Freelancer_Service> Freelancer_Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Payment_type> Payment_types { get; set; }



















    }
}
