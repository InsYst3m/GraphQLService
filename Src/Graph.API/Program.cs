using Graph.API.Configuration;
using Graph.API.Extensions;
using Graph.API.General;
using Graph.API.Services;
using Graph.API.Services.Interfaces;
using Microsoft.Extensions.Options;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


#region Configure Services

IServiceCollection services = builder.Services;

services.Configure<GraphServiceSettings>(configuration.GetSection(GraphServiceSettings.SECTION_NAME),
    options => options.BindNonPublicProperties = true);

services.Configure<CoinGeckoSettings>(configuration.GetSection(CoinGeckoSettings.SECTION_NAME),
    options => options.BindNonPublicProperties = true);

services.AddHttpClient(
    Constants.HTTP_CLIENT_COIN_GECKO_KEY,
    (serviceProvider, httpClient) =>
    {
        string baseAddress = 
            serviceProvider.GetRequiredService<IOptionsMonitor<CoinGeckoSettings>>().CurrentValue.BaseAddress;

        httpClient.BaseAddress = new Uri(baseAddress);
    });

services.AddScoped<ICryptoService, CryptoService>();

services.ConfigureGraphQLServer();

#endregion


#region Configure Pipeline

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });

#endregion


app.Run();

