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
    public class AtendimentosUsuariosController : ControllerBase
    {
        private readonly IAtendimentoUsuarioRepository _repository;
        private readonly ILogger<AtendimentosUsuariosController> _logger;

        public AtendimentosUsuariosController(IAtendimentoUsuarioRepository repository, ILogger<AtendimentosUsuariosController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var atendimentos = _repository.ObterTodos();

            if (atendimentos == null) return NotFound("Nenhum atendimento encontrado.");

            var atendimentosDto = atendimentos.Select(a => new AtendimentoUsuarioDTO
            {
                AtendimentoUsuarioId = a.AtendimentoUsuarioId,
                UsuarioId = a.UsuarioId,
                DentistaId = a.DentistaId,
                ClinicaId = a.ClinicaId,
                DataAtendimento = a.DataAtendimento,
                DescricaoProcedimento = a.DescricaoProcedimento,
                Custo = a.Custo,
                DataRegistro = a.DataRegistro

            });

            return Ok(atendimentosDto);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var atendimento = _repository.ObterPorId(id);

            if (atendimento == null)
            {
                return NotFound("O atendimento não foi encontrado.");
            }

            var atendimentoDto = new AtendimentoUsuarioDTO
            {
                AtendimentoUsuarioId = atendimento.AtendimentoUsuarioId,
                UsuarioId = atendimento.UsuarioId,
                DentistaId = atendimento.DentistaId,
                ClinicaId = atendimento.ClinicaId,
                DataAtendimento = atendimento.DataAtendimento,
                DescricaoProcedimento = atendimento.DescricaoProcedimento,
                Custo = atendimento.Custo,
                DataRegistro = atendimento.DataRegistro
            };

            return Ok(atendimentoDto);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo atendimento", Description = "Adiciona um novo atendimento ao banco de dados.")]
        [SwaggerResponse(201, "Atendimento criado com sucesso.", typeof(AtendimentoUsuario))]
        [SwaggerResponse(400, "A solicitação é inválida.")]
        [SwaggerResponse(404, "Usuário, dentista ou clínica não encontrados.")]
        public IActionResult Post([FromBody] AtendimentoUsuarioCreateDTO atendimentoCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_repository.VerificarUsuarioPorId(atendimentoCreateDto.UsuarioId))
            {
                return NotFound(new { Mensagem = "Usuário não encontrado.", UsuarioId = atendimentoCreateDto.UsuarioId });
            }

            if (!_repository.VerificarDentistaPorId(atendimentoCreateDto.DentistaId))
            {
                return NotFound(new { Mensagem = "Dentista não encontrado.", DentistaId = atendimentoCreateDto.DentistaId });
            }

            if (!_repository.VerificarClinicaPorId(atendimentoCreateDto.ClinicaId))
            {
                return NotFound(new { Mensagem = "Clínica não encontrada.", ClinicaId = atendimentoCreateDto.ClinicaId });
            }

            var atendimento = new AtendimentoUsuario
            {
                UsuarioId = atendimentoCreateDto.UsuarioId,
                DentistaId = atendimentoCreateDto.DentistaId,
                ClinicaId = atendimentoCreateDto.ClinicaId,
                DataAtendimento = atendimentoCreateDto.DataAtendimento,
                DescricaoProcedimento = atendimentoCreateDto.DescricaoProcedimento,
                Custo = atendimentoCreateDto.Custo,
                DataRegistro = atendimentoCreateDto.DataRegistro
            };

            _repository.AdicionarAtendimento(atendimento);

            _logger.LogInformation("Atendimento com ID criado com sucesso.");

            return CreatedAtAction(nameof(Get), new { id = atendimento.AtendimentoUsuarioId }, atendimento);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] AtendimentoUsuarioCreateDTO atendimentoCreateDto)
        {
            if (atendimentoCreateDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var atendimentoExistente = _repository.ObterPorId(id);

            if (atendimentoExistente == null)
            {
                return NotFound("O atendimento não foi encontrado.");
            }

            atendimentoExistente.DataAtendimento = atendimentoCreateDto.DataAtendimento;
            atendimentoExistente.DescricaoProcedimento = atendimentoExistente.DescricaoProcedimento;
            atendimentoExistente.Custo = atendimentoCreateDto.Custo;

            _repository.AtualizarAtendimento(atendimentoExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var atendimentoExistente = _repository.ObterPorId(id);

            if (atendimentoExistente == null) return NotFound("O atendimento não foi encontrado.");

            _repository.DeletarAtendimento(id);

            _logger.LogInformation("Atendimento com ID {Id} excluído com sucesso.", id);

            return NoContent();
        }
    }
}
