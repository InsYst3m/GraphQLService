using BenchmarkDotNet.Attributes;

namespace Graph.API.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.SlowestToFastest)]
    [RankColumn]
    public class GraphApiProcessBechmark
    {
        private static readonly GraphApiProcess process = new();

        [Benchmark]
        public async Task GetGlobalMarketDataAsync()
        {
            await process.GetGlobalMarketDataAsync();
        }
    }
}
