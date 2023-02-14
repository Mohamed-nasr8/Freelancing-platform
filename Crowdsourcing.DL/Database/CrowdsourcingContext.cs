﻿using Crowdsourcing.DL.Entity;
using Crowdsourcing.DL.Models;
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
        public CrowdsourcingContext(DbContextOptions<CrowdsourcingContext> options):base(options)
        {

        }
        

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<OtherSkills> OtherSkills { get; set; }
        public DbSet<Verification> Verifications { get; set; }
        public DbSet<FreelancerService> FreelancerServices { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Expereince> Expereinces { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<HasFreelancerService> HasFreelancerServices { get; set; }
        public DbSet<HasSkill> HasSkills { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<ProposalStatusCatalog> ProposalStatusCatalogs { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>()
            .HasOne(p => p.Freelancer)
            .WithMany(b => b.Notifications)
            .HasForeignKey(p => p.FreelancerId);
        }



















    }
}