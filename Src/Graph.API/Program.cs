using Graph.API.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;


#region Configure Services

IServiceCollection services = builder.Services;

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

