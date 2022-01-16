using Graph.API.GraphQL;

namespace Graph.API.Extensions
{
    public static class GraphServiceConfigurationExtensions
    {
        public static IServiceCollection ConfigureGraphQLServer(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<CryptoQuery>();

            return services;
        }
    }
}
