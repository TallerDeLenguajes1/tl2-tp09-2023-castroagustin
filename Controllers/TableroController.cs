using Microsoft.AspNetCore.Mvc;
using webApi.Repositorios;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private TableroRepository tableroRepository;
    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tableroRepository = new TableroRepository();
    }

    [HttpPost("api/tablero")]
    public ActionResult<Tablero> CreateTablero(Tablero tablero)
    {
        tableroRepository.Create(tablero);
        return Ok(tablero);
    }

    [HttpPut("api/tablero/{idTablero}")]
    public ActionResult<Tablero> UpdateTablero(int idTablero, Tablero tablero)
    {
        tableroRepository.Update(idTablero, tablero);
        return Ok(tablero);
    }

    [HttpGet("api/tablero/{idTablero}")]
    public ActionResult<Tablero> GetTablero(int idTablero)
    {
        var tablero = tableroRepository.Get(idTablero);
        return Ok(tablero);
    }

    [HttpGet("api/tablero")]
    public ActionResult<List<Tablero>> GetAllTableros()
    {
        var tableros = tableroRepository.GetAll();
        return Ok(tableros);
    }

    [HttpDelete("api/tablero/{idTablero}")]
    public ActionResult<Tablero> DeleteTablero(int idTablero)
    {
        tableroRepository.Remove(idTablero);
        return Ok(idTablero);
    }
}
