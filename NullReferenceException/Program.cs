// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

string nome = null;
ImprimirTamanho(nome);

static void ImprimirTamanho(string s)
{
    Console.WriteLine(s.Length);
}