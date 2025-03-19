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
    public class PrevisoesController : ControllerBase
    {
        private readonly IPrevisaoRepository _repository;
        private readonly ILogger<PrevisoesController> _logger;

        public PrevisoesController(IPrevisaoRepository repository, ILogger<PrevisoesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var previsoes = _repository.ObterTodos();

            if (previsoes == null || !previsoes.Any())
                return NotFound("Nenhuma previsão encontrada.");

            var previsoesDto = previsoes.Select(p => new PrevisaoDTO
            {
                PrevisaoId = p.PrevisaoId,
                ImagemId = p.ImagemId,
                UsuarioId = p.UsuarioId,
                PrevisaoTexto = p.PrevisaoTexto,
                Probabilidade = p.Probabilidade,
                Recomendacao = p.Recomendacao,
                DataPrevisao = p.DataPrevisao
            });

            return Ok(previsoesDto);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var previsao = _repository.ObterPorId(id);

            if (previsao == null)
            {
                return NotFound("A previsão não foi encontrada.");
            }

            var previsaoDto = new PrevisaoDTO
            {
                PrevisaoId = previsao.PrevisaoId,
                ImagemId = previsao.ImagemId,
                UsuarioId = previsao.UsuarioId,
                PrevisaoTexto = previsao.PrevisaoTexto,
                Probabilidade = previsao.Probabilidade,
                Recomendacao = previsao.Recomendacao,
                DataPrevisao = previsao.DataPrevisao
            };

            return Ok(previsaoDto);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova previsão", Description = "Adiciona uma nova previsão ao banco de dados.")]
        [SwaggerResponse(201, "Previsão criada com sucesso.", typeof(Previsao))]
        [SwaggerResponse(400, "A solicitação é inválida.")]
        [SwaggerResponse(404, "Usuário ou imagem não encontrados.")]
        public IActionResult Post([FromBody] PrevisaoCreateDTO previsaoCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_repository.VerificarUsuarioPorId(previsaoCreateDto.UsuarioId))
            {
                return NotFound(new { Mensagem = "Usuário não encontrado.", UsuarioId = previsaoCreateDto.UsuarioId });
            }

            if (!_repository.VerificarImagemPorId(previsaoCreateDto.ImagemId))
            {
                return NotFound(new { Mensagem = "Imagem não encontrado.", ImagemId = previsaoCreateDto.ImagemId });
            }

            var previsao = new Previsao
            {
                UsuarioId = previsaoCreateDto.UsuarioId,
                ImagemId = previsaoCreateDto.ImagemId,
                PrevisaoTexto = previsaoCreateDto.PrevisaoTexto,
                Probabilidade = previsaoCreateDto.Probabilidade,
                Recomendacao = previsaoCreateDto.Recomendacao,
                DataPrevisao = previsaoCreateDto.DataPrevisao
            };

            _repository.AdicionarPrevisao(previsao);

            _logger.LogInformation("Previsão com ID {PrevisaoUsuarioId} criada com sucesso.", previsao.PrevisaoId);

            return CreatedAtAction(nameof(Get), new { id = previsao.PrevisaoId }, previsao);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] PrevisaoCreateDTO previsaoCreateDto)
        {
            if (previsaoCreateDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var previsaoExistente = _repository.ObterPorId(id);

            if (previsaoExistente == null)
            {
                return NotFound("A previsão não foi encontrada.");
            }

            previsaoExistente.ImagemId = previsaoCreateDto.ImagemId;
            previsaoExistente.UsuarioId = previsaoCreateDto.UsuarioId;
            previsaoExistente.PrevisaoTexto = previsaoCreateDto.PrevisaoTexto;
            previsaoExistente.Probabilidade = previsaoCreateDto.Probabilidade;
            previsaoExistente.Recomendacao = previsaoCreateDto.Recomendacao;

            _repository.AtualizarPrevisao(previsaoExistente);

            _logger.LogInformation("Previsão com ID {PrevisaoUsuarioId} atualizada com sucesso.", id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var previsaoExistente = _repository.ObterPorId(id);

            if (previsaoExistente == null)
                return NotFound("A previsão não foi encontrada.");

            _repository.DeletarPrevisao(id);

            _logger.LogInformation("Previsão com ID {PrevisaoUsuarioId} excluída com sucesso.", id);

            return NoContent();
        }
    }
}
