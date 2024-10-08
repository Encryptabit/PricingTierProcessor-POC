namespace PricingTierProcessor_POC.Services;

using Microsoft.Extensions.Caching.Memory;
using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;
using System.Threading.Tasks;
using WorkOS;

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

    public async Task<WorkOSList<Connection>> GetWorkOSConnectionsAsync()
    {
        if(!_cache.TryGetValue("SSOOrganizations", out WorkOSList<Connection> connections)) { 
            Interlocked.Increment(ref _cacheMisses);

            // async fetch workos api
            connections = await _fetchService.FetchWorkOSConnectionsAsync();

            _cache.Set<WorkOSList<Connection>>("SSOOrganizations", connections, TimeSpan.FromMinutes(60));
        } else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return connections;
    }

    public async Task<List<int>> GetRestApiParticipantsAsync()
    {
        if (!_cache.TryGetValue("RestApiParticipants", out List<int> restApiParticipants))
        {
            Interlocked.Increment(ref _cacheMisses);

            // Call IdentityServer 
            restApiParticipants = await _fetchService.FetchRestApiParticipantsAsync();
           
            _cache.Set<List<int>>("RestApiParticipants", restApiParticipants, TimeSpan.FromMinutes(60));
        } else
        {
            Interlocked.Increment(ref _cacheHits);
        }

        return restApiParticipants;
    }
}
