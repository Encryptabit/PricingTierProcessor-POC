namespace PricingTierProcessor_POC.Controllers;
using Microsoft.AspNetCore.Mvc;
using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;
using PricingTierProcessor_POC.Services;

[ApiController]
[Route("[controller]")]
public class WorkOSApiController : ControllerBase
{
    private  ILogger<WorkOSApiController> _logger;
    private readonly  IAccountingService _accountingService;
    private readonly ICacheService _cacheService;

    public WorkOSApiController(ILogger<WorkOSApiController> logger, ICacheService cacheService, IAccountingService accountingService)
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

    [HttpGet(Name = "ListConnections")]
    public async Task<List<WorkOSConnection>> FetchConnectionsFromWorkOSAsync()
    {

        return await _cacheService.GetWorkOSConnectionsAsync();
    } 


}
