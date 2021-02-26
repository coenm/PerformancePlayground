# PerformancePlayground

## Howto build and run

```bash
git clone https://github.com/coenm/PerformancePlayground
cd PerformancePlayground
dotnet restore PerformancePlayground.sln
dotnet build -c release PerformancePlayground.sln
dotnet run -c release --project PerformancePlayground.Console\PerformancePlayground.Console.csproj
```