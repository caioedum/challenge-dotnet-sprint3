using Microsoft.AspNetCore.Mvc;
using WebApiChallenge.Models;
using WebApiChallenge.Repositories;

[ApiController]
[Route("[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioRepository _repository;

    public UsuariosController(UsuarioRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var usuarios = _repository.GetAll();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var usuario = _repository.GetById(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Usuario usuario)
    {
        _repository.Add(usuario);
        return CreatedAtAction(nameof(Get), new { id = usuario.UsuarioId }, usuario);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Usuario usuario)
    {
        if (id != usuario.UsuarioId) return BadRequest();

        _repository.Update(usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repository.Delete(id);
        return NoContent();
    }
}
