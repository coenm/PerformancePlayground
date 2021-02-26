using BenchmarkDotNet.Running;

namespace PerformancePlayground.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly, new Config());
            // BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new Config());
            System.Console.WriteLine("Done. Press Enter");
            System.Console.ReadLine();
        }
    }
}
