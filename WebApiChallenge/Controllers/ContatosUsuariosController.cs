using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApiChallenge.DTO;
using WebApiChallenge.Interfaces;
using WebApiChallenge.Models;

namespace WebApiChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosUsuariosController : ControllerBase
    {
        private readonly IContatoUsuarioRepository _repository;
        private readonly ILogger<ContatosUsuariosController> _logger;

        public ContatosUsuariosController(IContatoUsuarioRepository repository, ILogger<ContatosUsuariosController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contatos = _repository.ObterTodos();

            if (contatos == null || !contatos.Any())
                return NotFound("Nenhum contato encontrado.");

            var contatosDto = contatos.Select(c => new ContatoUsuarioDTO
            {
                ContatoUsuarioId = c.ContatoUsuarioId,
                UsuarioId = c.UsuarioId,
                EmailUsuario = c.EmailUsuario,
                TelefoneUsuario = c.TelefoneUsuario
            });

            return Ok(contatosDto);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var contato = _repository.ObterPorId(id);

            if (contato == null)
            {
                return NotFound("O contato não foi encontrado.");
            }

            var contatoDto = new ContatoUsuarioDTO
            {
                ContatoUsuarioId = contato.ContatoUsuarioId,
                UsuarioId = contato.UsuarioId,
                EmailUsuario = contato.EmailUsuario,
                TelefoneUsuario = contato.TelefoneUsuario
            };

            return Ok(contatoDto);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo contato", Description = "Adiciona um novo contato ao banco de dados.")]
        [SwaggerResponse(201, "Contato criado com sucesso.", typeof(ContatoUsuario))]
        [SwaggerResponse(400, "A solicitação é inválida.")]
        [SwaggerResponse(404, "Usuário não encontrado.")]
        [SwaggerResponse(409, "Telefone ou e-mail já cadastrados.")]
        public IActionResult Post([FromBody] ContatoUsuarioCreateDTO contatoCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repository.VerificarUsuarioPorId(contatoCreateDto.UsuarioId))
                return NotFound(new { Mensagem = "Usuário não encontrado.", UsuarioId = contatoCreateDto.UsuarioId });

            if (_repository.EmailJaCadastrado(contatoCreateDto.EmailUsuario))
                return Conflict(new { Mensagem = "E-mail já cadastrado.", Email = contatoCreateDto.EmailUsuario });

            if (_repository.TelefoneJaCadastrado(contatoCreateDto.TelefoneUsuario))
                return Conflict(new { Mensagem = "Telefone já cadastrado.", Telefone = contatoCreateDto.TelefoneUsuario });

            var contato = new ContatoUsuario
            {
                UsuarioId = contatoCreateDto.UsuarioId,
                EmailUsuario = contatoCreateDto.EmailUsuario,
                TelefoneUsuario = contatoCreateDto.TelefoneUsuario
            };

            _repository.AdicionarContato(contato);

            _logger.LogInformation("Contato com ID {ContatoUsuarioId} criado com sucesso.", contato.ContatoUsuarioId);

            return CreatedAtAction(nameof(Get), new { id = contato.ContatoUsuarioId }, contato);
        }


        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] ContatoUsuarioCreateDTO contatoCreateDto)
        {
            if (contatoCreateDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var contatoExistente = _repository.ObterPorId(id);

            if (contatoExistente == null)
            {
                return NotFound("O contato não foi encontrado.");
            }

            contatoExistente.EmailUsuario = contatoCreateDto.EmailUsuario;
            contatoExistente.TelefoneUsuario = contatoCreateDto.TelefoneUsuario;

            _repository.AtualizarContato(contatoExistente);

            _logger.LogInformation("Contato com ID {ContatoUsuarioId} atualizado com sucesso.", id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var contatoExistente = _repository.ObterPorId(id);

            if (contatoExistente == null)
                return NotFound("O contato não foi encontrado.");

            _repository.DeletarContato(id);

            _logger.LogInformation("Contato com ID {ContatoUsuarioId} excluído com sucesso.", id);

            return NoContent();
        }
    }
}
