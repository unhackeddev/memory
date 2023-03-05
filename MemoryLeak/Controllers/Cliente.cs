namespace MemoryLeak.Controllers;

public class Cliente: IEqualityComparer<Cliente>
{
    public Guid Id {get; set;}
    public string Nome {get; set;}

    public Cliente(Guid id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public bool Equals(Cliente? x, Cliente? y)
            => (x?.Id == y?.Id);

        public int GetHashCode(Cliente cliente) =>
            cliente?.Id.GetHashCode() ?? throw new ArgumentNullException(nameof(cliente));
}