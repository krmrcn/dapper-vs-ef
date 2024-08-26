using BenchmarkDotNet.Running;

namespace dapper_vs_ef
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
