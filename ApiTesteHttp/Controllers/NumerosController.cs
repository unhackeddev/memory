using Microsoft.AspNetCore.Mvc;

namespace ApiTesteHttp.Controllers;

[ApiController]
[Route("[controller]")]
public class NumerosController : ControllerBase
{
    private readonly ILogger<NumerosController> _logger;

    public NumerosController(ILogger<NumerosController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<int> Get([FromQuery] int quantidade)
    {
        return Enumerable.Range(1, quantidade).Select(index => index)
        .ToArray();
    }
}
