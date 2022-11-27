using Graph.API.GraphQL;

using HotChocolate.Execution.Options;

namespace Graph.API.Extensions
{
    public static class GraphServiceConfigurationExtensions
    {
        public static IServiceCollection ConfigureGraphQLServer(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .SetRequestOptions(_ => new RequestExecutorOptions
                {
                    IncludeExceptionDetails = true
                })
                .AddQueryType<CryptoQuery>();

            return services;
        }
    }
}
