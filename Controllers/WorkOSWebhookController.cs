using Microsoft.AspNetCore.Mvc;
using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;

namespace PricingTierProcessor_POC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkOSWebhookController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WorkOSWebhookController> _logger;
        private readonly IAccountingService _accountingService;

        public WorkOSWebhookController(ILogger<WorkOSWebhookController> logger, IAccountingService accountingService)
        {
            _logger = logger;
            _accountingService = accountingService;
        }

        [HttpPost(Name = "ReceiveEvent")]
        public async Task<IActionResult> ReceiveEvent([FromBody] WorkOSEvent webhookEvent)
        {
            try
            {
                // Validate the incoming event (security, signature checks, etc.)
                //if (!IsValidWorkOsEvent(webhookEvent))
                //{
                //    return BadRequest("Invalid webhook signature.");
                //}

                // Process the event
                await _accountingService.HandleWorkOSEventAsync(webhookEvent);

                return Ok();
            }
            catch (Exception ex)
            {
                // Log error and return failure response
                Console.WriteLine($"Error processing WorkOS event: {ex.Message}");
                return StatusCode(500, "Internal server error.");
            }
        }


    }
}
