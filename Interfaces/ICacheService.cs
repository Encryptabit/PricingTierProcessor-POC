using PricingTierProcessor_POC.Models;
using WorkOS;

namespace PricingTierProcessor_POC.Interfaces
{
    public interface ICacheService
    {
        Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync();
    }
}