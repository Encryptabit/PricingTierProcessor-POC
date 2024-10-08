using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;

namespace PricingTierProcessor_POC.Services;

public class FetchService : IFetchService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public FetchService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<WorkOSConnection>> FetchSSOOrganizationsFromWorkOSAsync()
    {
        await Task.Delay(1000);
        // Must add processing to only return the connections with active status, should probably use IAsyncEnumerable
        return new List<WorkOSConnection> { new WorkOSConnection() };
    }

}
