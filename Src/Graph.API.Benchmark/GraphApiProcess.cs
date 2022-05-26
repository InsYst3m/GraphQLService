﻿using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;

namespace Graph.API.Benchmark
{
    public class GraphApiProcess
    {
        private readonly IGraphApiClient _graphApiClient;

        public GraphApiProcess()
        {
            ServiceCollection serviceCollection = new();

            serviceCollection
                .AddGraphApiClient()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://insyst3m-002-site1.btempurl.com/graphql/"));

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            _graphApiClient = serviceProvider.GetRequiredService<IGraphApiClient>();
        }

        public async Task<IOperationResult<IGetGlobalMarketDataResult>> GetGlobalMarketDataAsync()
        {
            IOperationResult<IGetGlobalMarketDataResult> result = await _graphApiClient.GetGlobalMarketData.ExecuteAsync();

            result.EnsureNoErrors();

            return result;
        }
    }
}
