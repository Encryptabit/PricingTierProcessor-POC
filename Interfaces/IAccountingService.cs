using PricingTierProcessor_POC.Models;

namespace PricingTierProcessor_POC.Interfaces
{
    public interface IAccountingService
    {
        Task HandleWorkOSEventAsync(WorkOSEvent workOSEvent);
        Task UpdateAccountTierAsync(int accountId);
    }
}
