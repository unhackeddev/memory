using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


Console.WriteLine("Usando Streams com HttpClient");
BenchmarkRunner.Run(typeof(TesteBenchmark));


[MemoryDiagnoser]
public class TesteBenchmark
{
    private string? _url;

    private HttpClient? _httpClient;

    [GlobalSetup]
    public void Setup()
    {
        _httpClient = new HttpClient();
        _url = "http://localhost:5185/Numeros?quantidade=100000";
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _httpClient?.Dispose();
    }

    [Benchmark]
    //public async Task<List<int>> UsingResponseContentRead()
    public async Task UsingResponseContentRead()
    {
        using (var response = await _httpClient!.GetAsync(_url, HttpCompletionOption.ResponseContentRead))
        {
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                //return await JsonSerializer.DeserializeAsync<List<int>>(stream);
                await Task.CompletedTask;
            }
        }
    }

    [Benchmark]
    //public async Task<List<int>> UsingResponseHeadersRead()
    public async Task UsingResponseHeadersRead()
    {
        using (var response = await _httpClient!.GetAsync(_url, HttpCompletionOption.ResponseHeadersRead))
        {
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
               // return await JsonSerializer.DeserializeAsync<List<int>>(stream);
                await Task.CompletedTask;
            }
        }
    }
}




