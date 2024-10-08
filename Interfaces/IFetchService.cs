using PricingTierProcessor_POC.Models;
using WorkOS;

namespace PricingTierProcessor_POC.Interfaces
{
    public interface IFetchService
    {
        Task<List<int>> FetchRestApiParticipantsAsync();
        Task<WorkOSList<Connection>> FetchWorkOSConnectionsAsync();
    }
}