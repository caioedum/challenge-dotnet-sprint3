using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiChallenge.DTO;
using WebApiChallenge.Interfaces;
using WebApiChallenge.Models;
using WebApiChallenge.Repositories;

namespace WebApiChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _repository.ObterTodos();

            if (usuarios == null) return NotFound("Nenhum usuário encontrado.");

            var usuariosDto = usuarios.Select(u => new UsuarioDTO
            {
                UsuarioId = u.UsuarioId,
                Cpf = u.Cpf,
                Nome = u.Nome,
                Sobrenome = u.Sobrenome,
                DataNascimento = u.DataNascimento,
                Genero = u.Genero,
                DataCadastro = u.DataCadastro
            });

            return Ok(usuariosDto);
        }


        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var usuario = _repository.ObterPorId(id);

            if (usuario == null)
            {
                return NotFound("O usuário não foi encontrado.");
            }

            var usuarioDto = new UsuarioDTO
            {
                UsuarioId = usuario.UsuarioId,
                Cpf = usuario.Cpf,
                Nome = usuario.Nome,
                Sobrenome = usuario.Sobrenome,
                DataNascimento = usuario.DataNascimento,
                Genero = usuario.Genero,
                DataCadastro = usuario.DataCadastro
            };

            return Ok(usuarioDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioCreateDTO usuarioCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = new Usuario
            {
                Cpf = usuarioCreateDto.Cpf,
                Nome = usuarioCreateDto.Nome,
                Sobrenome = usuarioCreateDto.Sobrenome,
                DataNascimento = usuarioCreateDto.DataNascimento,
                Genero = usuarioCreateDto.Genero,
                DataCadastro = usuarioCreateDto.DataCadastro ?? DateTime.Now
            };

            _repository.AdicionarUsuario(usuario);

            return CreatedAtAction(nameof(Get), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] UsuarioCreateDTO usuarioCreateDto)
        {
            if (usuarioCreateDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var usuarioExistente = _repository.ObterPorId(id);

            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.Cpf = usuarioCreateDto.Cpf;
            usuarioExistente.Nome = usuarioCreateDto.Nome;
            usuarioExistente.Sobrenome = usuarioCreateDto.Sobrenome;
            usuarioExistente.DataNascimento = usuarioCreateDto.DataNascimento;
            usuarioExistente.Genero = usuarioCreateDto.Genero;

            _repository.AtualizarUsuario(usuarioExistente);
            return NoContent();
        }
    }
}
