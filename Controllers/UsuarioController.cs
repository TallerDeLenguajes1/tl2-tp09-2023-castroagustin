using Microsoft.AspNetCore.Mvc;
using webApi.Repositorios;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioRepository usuarioRepository;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuarioRepository = new UsuarioRepository();
    }

    [HttpPost("api/usuario")]
    public ActionResult<Usuario> CreateUser(Usuario usuario)
    {
        usuarioRepository.Create(usuario);
        return Ok(usuario);
    }

    [HttpGet("api/usuario")]
    public ActionResult<List<Usuario>> GetAllUsers()
    {
        var usuarios = usuarioRepository.GetAll();
        return Ok(usuarios);
    }

    [HttpGet("api/usuario/{idUsuario}")]
    public ActionResult<Usuario> GetUser(int idUsuario)
    {
        var usuario = usuarioRepository.Get(idUsuario);
        return Ok(usuario);
    }

    [HttpPut("api/usuario/{idUsuario}")]
    public ActionResult<Usuario> UpdateUser(int idUsuario, Usuario usuario)
    {
        usuarioRepository.Update(idUsuario, usuario);
        return Ok(usuario);
    }

    [HttpDelete("api/usuario/{idUsuario}")]
    public ActionResult<Usuario> DeleteUser(int idUsuario)
    {
        usuarioRepository.Remove(idUsuario);
        return Ok(idUsuario);
    }
}
