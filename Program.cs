using Microsoft.Extensions.Caching.Memory;
using PricingTierProcessor_POC.Interfaces;
using PricingTierProcessor_POC.Services;
using WorkOS;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// Application wide
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();

// My own
builder.Services.AddScoped<ICacheService,CacheService>();
builder.Services.AddScoped<IFetchService,FetchService>();
builder.Services.AddScoped<IAccountingService, AccountingService>();
builder.Services.AddScoped<SSOService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
