// * Summary *

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 7500F, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.303
  [Host] : .NET 8.0.7 (8.0.724.31311), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI

Job=MediumRun  Toolchain=InProcessNoEmitToolchain  IterationCount=15
LaunchCount=2  WarmupCount=10

// * Hints *
Outliers
  Benchmark.EFQueryNoTrackingGet_All_Customers: MediumRun     -> 1 outlier  was  removed (236.03 us)
  Benchmark.EFLambdaTrackingGet_Filtered_Customers: MediumRun -> 2 outliers were detected (179.33 us, 179.41 us)

// * Legends *
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 us      : 1 Microsecond (0.000001 sec)

// * Diagnostic Output - MemoryDiagnoser *

// ***** BenchmarkRunner: End *****
Run time: 00:07:08 (428.84 sec), executed benchmarks: 10

Global total time: 00:07:09 (429.11 sec), executed benchmarks: 10
// * Artifacts cleanup *
Artifacts cleanup is finished

----------------------------------------------------------------------------------

| Method                                   | Mean     | Error   | StdDev  | Allocated |
|----------------------------------------- |---------:|--------:|--------:|----------:|
| EFTrackingGet_All_Customers              | 252.7 us | 1.42 us | 2.13 us | 132.38 KB |
| EFNoTrackingGet_All_Customers            | 213.9 us | 1.66 us | 2.49 us |   78.2 KB |
| EFQueryTrackingGet_All_Customers         | 227.5 us | 1.68 us | 2.51 us |  94.43 KB |
| EFQueryNoTrackingGet_All_Customers       | 233.2 us | 0.75 us | 1.12 us |  95.13 KB |
| DapperGet_All_Customers                  | 197.7 us | 0.52 us | 0.78 us |  60.13 KB |
| EFLambdaTrackingGet_Filtered_Customers   | 180.9 us | 0.49 us | 0.74 us |  31.57 KB |
| EFLambdaNoTrackingGet_Filtered_Customers | 171.0 us | 1.01 us | 1.51 us |  22.79 KB |
| EFQueryTrackingGet_Filtered_Customers    | 170.8 us | 1.19 us | 1.79 us |  36.88 KB |
| EFQueryNoTrackingGet_Filtered_Customers  | 175.2 us | 0.88 us | 1.29 us |  37.58 KB |
| DapperGet_Filtered_Customers             | 141.4 us | 0.97 us | 1.45 us |  15.59 KB |

----------------------------------------------------------------------------------

| Method                                   | Mean     | Error   | StdDev  | Allocated |
|----------------------------------------- |---------:|--------:|--------:|----------:|
| EFTrackingGet_All_Customers              | 248.4 us | 2.35 us | 5.25 us | 132.38 KB |
| EFNoTrackingGet_All_Customers            | 214.2 us | 1.13 us | 2.53 us |   78.2 KB |
| EFQueryTrackingGet_All_Customers         | 227.1 us | 0.50 us | 1.11 us |  94.43 KB |
| EFQueryNoTrackingGet_All_Customers       | 235.7 us | 0.97 us | 2.13 us |  95.13 KB |
| DapperGet_All_Customers                  | 192.9 us | 1.44 us | 3.22 us |  60.13 KB |
| EFLambdaTrackingGet_Filtered_Customers   | 181.4 us | 0.35 us | 0.78 us |  31.57 KB |
| EFLambdaNoTrackingGet_Filtered_Customers | 170.2 us | 0.34 us | 0.76 us |  22.79 KB |
| EFQueryTrackingGet_Filtered_Customers    | 168.9 us | 0.39 us | 0.86 us |  36.88 KB |
| EFQueryNoTrackingGet_Filtered_Customers  | 175.1 us | 0.36 us | 0.80 us |  37.58 KB |
| DapperGet_Filtered_Customers             | 140.6 us | 0.26 us | 0.58 us |  15.59 KB |

----------------------------------------------------------------------------------

| Method                                   | Mean     | Error   | StdDev  | Allocated |
|----------------------------------------- |---------:|--------:|--------:|----------:|
| EFTrackingGet_All_Customers              | 250.0 us | 2.27 us | 3.40 us | 132.38 KB |
| EFNoTrackingGet_All_Customers            | 215.5 us | 0.99 us | 1.49 us |   78.2 KB |
| EFQueryTrackingGet_All_Customers         | 228.6 us | 1.06 us | 1.58 us |  94.43 KB |
| EFQueryNoTrackingGet_All_Customers       | 234.7 us | 0.96 us | 1.44 us |  95.13 KB |
| DapperGet_All_Customers                  | 193.5 us | 1.92 us | 2.88 us |  60.13 KB |
| EFLambdaTrackingGet_Filtered_Customers   | 182.3 us | 0.73 us | 1.10 us |  31.57 KB |
| EFLambdaNoTrackingGet_Filtered_Customers | 170.7 us | 0.46 us | 0.64 us |  22.79 KB |
| EFQueryTrackingGet_Filtered_Customers    | 169.6 us | 0.58 us | 0.85 us |  36.88 KB |
| EFQueryNoTrackingGet_Filtered_Customers  | 175.0 us | 0.45 us | 0.68 us |  37.58 KB |
| DapperGet_Filtered_Customers             | 140.2 us | 0.70 us | 1.05 us |  15.59 KB |