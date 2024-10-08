using PricingTierProcessor_POC.Models;

namespace PricingTierProcessor_POC.Interfaces
{
    public interface IFetchService
    {
        Task<List<WorkOSConnection>> FetchSSOOrganizationsFromWorkOSAsync();
    }
}