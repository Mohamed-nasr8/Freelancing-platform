using Crowdsourcing.BL.Helper;
using Crowdsourcing.BL.Interface;
using Crowdsourcing.BL.Repository;
using Crowdsourcing.DL.Entity;
using Crowdsourcing.Paypal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace Crowdsourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly string _stripeApiKey;
        private readonly string _stripeSecretKey;
        private readonly IRepository<Freelancer> _freelancerRepository;
        private readonly IRepository<Proposal> _proposalRepo;

        public PaymentController(IOptions<StripeSettings> stripeSettings, IRepository<Freelancer> freelancerRepository, IRepository<Proposal> proposalRepo)
        {
            _stripeApiKey = stripeSettings.Value.ApiKey;
            _stripeSecretKey = stripeSettings.Value.SecretKey;
            _freelancerRepository = freelancerRepository;
            _proposalRepo = proposalRepo;
        }


        [HttpPost("TransferMoney")]
        public async Task<IActionResult> TransferMoneyAsync(int proposalId)
        {
            try
            {
                StripeConfiguration.ApiKey = _stripeSecretKey;

                var proposal = await _proposalRepo.GetAsync(proposalId);
                var freelancer = await _freelancerRepository.GetAsync(proposal.FreelancerId);
         
                var Price = proposal.PaymentAmount.ToString();
                decimal feePercentage = 0.1m; // 10% fee
                decimal feeAmount = proposal.PaymentAmount * feePercentage;
                // Create a price in Stripe
                var priceOptions = new PriceCreateOptions
                {
                    UnitAmount = (long)(proposal.PaymentAmount * 100), // Convert payment amount to cents
                    Currency = "usd", // Set the currency according to your needs
                    ProductData = new PriceProductDataOptions
                    {
                        Name = "Proposal Payment", // Set the name of the product
                    },
                };

                var priceService = new PriceService();
                var price = await priceService.CreateAsync(priceOptions);

                // Create a payment session
                var options = new SessionCreateOptions
                {
                    Mode = "payment",
                    LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions { Price = price.Id, Quantity = 1 },
            },
                    PaymentIntentData = new SessionPaymentIntentDataOptions
                    {
                        ApplicationFeeAmount = (long)(feeAmount * 100), // Convert fee amount to cents
                        TransferData = new SessionPaymentIntentDataTransferDataOptions
                        {
                            Destination = freelancer.StripeAccountId,
                       
                        },
                    },
                    SuccessUrl = "https://example.com/success",
                    CancelUrl = "https://example.com/cancel",
                };
                var servicea = new AccountService();
                 var account = await servicea.GetAsync(freelancer.StripeAccountId);
                var czp = account.Capabilities.Transfers;

                var service = new SessionService();
                var session = service.Create(options);

                return Ok(new ApiResponse<string>()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "Payment Session Created",
                    Data = session.Id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {
                    Code = "400",
                    Status = "Failed",
                    Message = "Failed to Create Payment Session",
                    Error = ex.Message
                });
            }
        }




    }
}




