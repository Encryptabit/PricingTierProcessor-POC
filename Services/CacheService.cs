namespace PricingTierProcessor_POC.Services;

using Microsoft.Extensions.Caching.Memory;
using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;
using System.Threading.Tasks;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _cache;
    private static int _cacheHits = 0;
    private static int _cacheMisses = 0;
    private readonly IFetchService _fetchService;

    public CacheService(IMemoryCache cache, IFetchService fetchService)
    {
        _cache = cache;
        _fetchService = fetchService;
    }

    public async Task<List<WorkOSConnection>> GetWorkOSConnectionsAsync()
    {
        return await _fetchService.FetchSSOOrganizationsFromWorkOSAsync();
    }
}
