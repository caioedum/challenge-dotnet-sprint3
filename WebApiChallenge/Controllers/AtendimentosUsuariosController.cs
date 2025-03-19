using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public AtendimentosUsuariosController(IAtendimentoUsuarioRepository repository)
        {
            _repository = repository;
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

            return CreatedAtAction(nameof(Get), new { id = atendimento.AtendimentoUsuarioId }, atendimento);
        }

    }
}
