namespace PricingTierProcessor_POC.Services;
using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;

public class AccountingService : IAccountingService
{
    private readonly ILogger<AccountingService> _logger;
    public AccountingService(ILogger<AccountingService> logger) {
        _logger = logger;
    }
    public async Task HandleWorkOSEventAsync(WorkOSEvent workOSEvent)
    {
        await Task.Delay(1000);
        _logger.LogDebug(workOSEvent.ToString());
    }

    public async Task UpdateAccountTierAsync(int accountId)
    {
        await Task.Delay(1000);
    }
}
