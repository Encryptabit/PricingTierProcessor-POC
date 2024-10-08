using PricingTierProcessor_POC.Models;
using WorkOS;

namespace PricingTierProcessor_POC.Interfaces
{
    public interface ICacheService
    {
        Task<List<int>> GetRestApiParticipantsAsync();
        Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync();
    }
}