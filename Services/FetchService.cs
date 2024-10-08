using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;
using WorkOS;
namespace PricingTierProcessor_POC.Services;

public class FetchService : IFetchService
{
    private readonly string API_KEY = "<<NOT TODAY GITHUB>>";
    private readonly string API_BASE_URL= "https://api.workos.com";
    private readonly SSOService _ssoService;

    public FetchService(IHttpClientFactory httpClientFactory, SSOService ssoService)
    {
        // _httpClientFactory = httpClientFactory; -- probably will be used for REST API query
        WorkOS.WorkOS.SetApiKey(API_KEY);
        _ssoService = ssoService;
    }

    public async Task<WorkOSList<Connection>> FetchWorkOSConnectionsAsync()
    {
        return await _ssoService.ListConnections(); ;
    }

}
