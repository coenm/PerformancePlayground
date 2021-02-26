using System.Collections.Generic;
using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace PerformancePlayground.Console
{
    public class Config : ManualConfig
    {
        public Config()
        {
            AddJob(
                // Job.ShortRun,
                // Job.MediumRun,
                Job.LongRun);
            AddLogger(ConsoleLogger.Default);
            AddColumnProvider(DefaultColumnProviders.Instance);
            AddColumn(StatisticColumn.Min, StatisticColumn.Max);
            AddExporter(
                CsvExporter.Default,
                MarkdownExporter.GitHub,
                HtmlExporter.Default);

            AddDiagnoser(MemoryDiagnoser.Default);
            UnionRule = ConfigUnionRule.AlwaysUseLocal;
        }

        private IEnumerable<IAnalyser> GetAnalysers()
        {
            yield return EnvironmentAnalyser.Default;
            yield return OutliersAnalyser.Default;
            yield return MinIterationTimeAnalyser.Default;
            yield return MultimodalDistributionAnalyzer.Default;
            yield return RuntimeErrorAnalyser.Default;
            yield return ZeroMeasurementAnalyser.Default;
            yield return BaselineCustomAnalyzer.Default;
        }
    }
}