namespace PricingTierProcessor_POC.Services;
using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;

public class AccountingService : IAccountingService
{
    private readonly ILogger<AccountingService> _logger;
    private readonly ICacheService _cacheService;
    public AccountingService(ILogger<AccountingService> logger, ICacheService cacheService) {
        _logger = logger;
        _cacheService = cacheService;
    }
    public async Task HandleWorkOSEventAsync(WorkOSEvent workOSEvent)
    {
        await Task.Delay(1000);
        _logger.LogDebug(workOSEvent.ToString());
    }

    public async Task UpdateAccountTierAsync(int accountId)
    {
        var ssoTask = _cacheService.GetWorkOSConnectionsAsync();

        await Task.WhenAll(ssoTask);

        var connections = await ssoTask;

        await Task.Delay(1000);
    }
}
