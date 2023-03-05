using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run(typeof(Teste));
Console.ReadLine();

[MemoryDiagnoser]
[DisassemblyDiagnoser(printSource: true)]
[Config(typeof(ConfigWithCustomEnvVars))]
public class Teste
{
    private class ConfigWithCustomEnvVars : ManualConfig
    {
        private const string JitObjectStackAllocation =
                                     "ComPlus_JitObjectStackAllocation";
        public ConfigWithCustomEnvVars()
        {
            AddJob(Job.Default
                   .WithEnvironmentVariables(new
                       EnvironmentVariable(JitObjectStackAllocation, "0"))
                   .WithId("JitObjectStackAllocation Off"));
            AddJob(Job.Default
                   .WithEnvironmentVariables(new
                       EnvironmentVariable(JitObjectStackAllocation, "1"))
                   .WithId("JitObjectStackAllocation On"));
        }
    }

    //[Params(1, 1)]
    public int A { get; set; }
    //[Params(1, 1)]
    public int B { get; set; }

    [Benchmark]
    public int Calcular()
    {
        var calculadora = new Calculadora(10, 20);
        return calculadora.Soma();
    }
}

public class Calculadora
{
    private int v1;
    private int v2;
    public Calculadora(int v1, int v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }
    internal int Soma()
    {
        return v1 + v2;
    }
}