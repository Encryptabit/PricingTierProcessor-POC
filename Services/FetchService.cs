using IdentityModel.Client;
using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Models;
using WorkOS;
namespace PricingTierProcessor_POC.Services;

public class FetchService : IFetchService
{
    private readonly string? API_KEY;
    private readonly string? API_BASE_URL;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _identityClient;
    private readonly SSOService _ssoService;


    public FetchService(IConfiguration config, IHttpClientFactory httpClientFactory, SSOService ssoService)
    {
        _configuration = config;

        // Get config vals
        API_KEY = _configuration["WorkOS:ApiKey"];
        API_BASE_URL = _configuration["WorkOS:BaseUrl"];
        
        // Identity setup
        _httpClientFactory = httpClientFactory;
        _identityClient = new HttpClient();

        // WorkOS setup
        WorkOS.WorkOS.SetApiKey(API_KEY);
        _ssoService = ssoService;

        // Identity Server Query setup
    }

    public async Task<WorkOSList<Connection>> FetchWorkOSConnectionsAsync()
    {
        return await _ssoService.ListConnections(); ;
    }

    public async Task<List<int>> FetchRestApiParticipantsAsync()
    {

        DiscoveryDocumentResponse discoveryDoc = await _identityClient.GetDiscoveryDocumentAsync(_configuration["IdentityServer:BaseUrl"]);
        var tokenResponse = await _identityClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = discoveryDoc.TokenEndpoint,
            ClientId = _configuration["IdentityServer:ClientId"],
            ClientSecret = _configuration["IdentityServer:ClientSecret"],
            Scope = "arcturuswebapi"
        });

        var client = _httpClientFactory.CreateClient();

        client.SetBearerToken(tokenResponse.AccessToken);

        string devUrl = _configuration["IdentityServer:DevUrl"],
            stageUrl = _configuration["IdentityServer:StagingUrl"];


        return await client.GetFromJsonAsync<List<int>>(devUrl);
    }

}
