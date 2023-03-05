using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;


namespace MemoryLeak.Controllers;

[ApiController]
[Route("[controller]")]
public class LeakController : ControllerBase
{
    private static ConcurrentDictionary<Guid, Cliente> _cache =
                            new ConcurrentDictionary<Guid, Cliente>();
    private readonly ILogger<LeakController> _logger;

    public LeakController(ILogger<LeakController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Post()
    {
        var id = Guid.NewGuid();
        var cliente = new Cliente(id, Gerar());
        _cache.TryAdd(id, cliente);

        return Ok();
    }

    private string Gerar()
    {
        Random rm = new Random();
        string retorno = string.Empty;
        for (int i = 0; i < 50; i++)
        {
            retorno += Convert.ToChar(rm.Next(65, 90));
        }
        return retorno;
    }
}
