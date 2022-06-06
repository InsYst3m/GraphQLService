using BenchmarkDotNet.Attributes;

namespace Graph.API.Benchmark
{
    [HtmlExporter]
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.SlowestToFastest)]
    [RankColumn]
    public class GraphApiProcessBenchmark
    {
        [Params(100, 200)]
        public int IterationCount;

        private static readonly GraphApiProcess _process = new();

        [Benchmark]
        public async Task GetSupportedCryptoAssetsAsync()
        {
            for (int i = 0; i < IterationCount; i++)
            {
                await _process.GetSupportedCryptoAssetsAsync();
            }
        }
    }
}
