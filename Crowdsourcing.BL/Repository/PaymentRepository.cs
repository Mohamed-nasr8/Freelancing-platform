using Crowdsourcing.BL.Interface;
using Crowdsourcing.DL.Database;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Repository
{
    public class PaymentRepository : IPaymentRepository
    {

        private readonly CrowdsourcingContext _context;

        public PaymentRepository(CrowdsourcingContext context)
        {
            _context = context;
        }
        public async Task<string> CreateConnectedAccount(int freelancerId)
        {
            var options = new AccountCreateOptions
            {
                Type = "express",
                //Country = "EG", // Set the country of the freelancer to Egypt
                Capabilities = new AccountCapabilitiesOptions
                {
                    CardPayments = new AccountCapabilitiesCardPaymentsOptions { Requested = true },
                    Transfers = new AccountCapabilitiesTransfersOptions { Requested = true },
                },
                BusinessType = "individual", // Set the business type to individual
                //TosAcceptance = new AccountTosAcceptanceOptions
                //{
                //    ServiceAgreement = "recipient", // Specify the recipient service agreement
                //}

            };

            var service = new AccountService();
            var account = await service.CreateAsync(options);

            // Associate the created account ID with the freelancer in your database
            var freelancer = await _context.Freelancers.FindAsync(freelancerId);
            freelancer.StripeAccountId = account.Id;
            await _context.SaveChangesAsync();

            return account.Id;
        }

    }
}
