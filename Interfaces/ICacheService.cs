using PricingTierProcessor_POC.Models;

namespace PricingTierProcessor_POC.Interfaces
{
    public interface ICacheService
    {
        Task<List<WorkOSConnection>> GetWorkOSConnectionsAsync();
    }
}