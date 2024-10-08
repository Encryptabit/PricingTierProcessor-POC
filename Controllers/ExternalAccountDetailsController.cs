namespace PricingTierProcessor_POC.Controllers;
using Microsoft.AspNetCore.Mvc;
using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;
using PricingTierProcessor_POC.Services;
using WorkOS;

[ApiController]
[Route("api/[controller]")]
public class ExternalAccountDetailsController : ControllerBase
{
    private  ILogger<ExternalAccountDetailsController> _logger;
    private readonly  IAccountingService _accountingService;
    private readonly ICacheService _cacheService;

    public ExternalAccountDetailsController(ILogger<ExternalAccountDetailsController> logger, ICacheService cacheService, IAccountingService accountingService)
    {
        _logger = logger;
        _cacheService = cacheService;
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

    [HttpGet("/query-workos")]
    public async Task<WorkOSList<Connection>> QueryWorkOS()
    {

        return await _cacheService.GetWorkOSConnectionsAsync();
    }

    [HttpGet("/query-identity-server")]
    public async Task<dynamic> QueryIdentityServer()
    {
        return await _cacheService.GetRestApiParticipantsAsync();
    }


}
