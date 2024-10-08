namespace PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;

public interface IAccountingService
{
    Task HandleWorkOSEventAsync(WorkOSEvent workOSEvent);
    Task UpdateAccountTierAsync(int accountId);
}
