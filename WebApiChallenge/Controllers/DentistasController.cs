using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiChallenge.DTO;
using WebApiChallenge.Interfaces;
using WebApiChallenge.Models;

namespace WebApiChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DentistasController : ControllerBase
    {
        private readonly IDentistaRepository _repository;

        public DentistasController(IDentistaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dentistas = _repository.ObterTodos();

            if (dentistas == null) return NotFound("Nenhum dentista encontrado.");

            var dentistasDto = dentistas.Select(d => new DentistaDTO
            {
                DentistaId = d.DentistaId,
                UsuarioId = d.UsuarioId,
                NomeDentista = d.EmailDentista,
                Especialidade = d.Especialidade,
                TelefoneDentista = d.TelefoneDentista,
                EmailDentista = d.EmailDentista

            });

            return Ok(dentistasDto);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var dentista = _repository.ObterPorId(id);

            if (dentista == null)
            {
                return NotFound("O dentista não foi encontrado.");
            }

            var dentistaDto = new DentistaDTO
            {
                DentistaId = dentista.DentistaId,
                UsuarioId = dentista.UsuarioId,
                NomeDentista = dentista.EmailDentista,
                Especialidade = dentista.Especialidade,
                TelefoneDentista = dentista.TelefoneDentista,
                EmailDentista = dentista.EmailDentista
            };

            return Ok(dentistaDto);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DentistaCreateDTO dentistaCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dentista = new Dentista
            {
                NomeDentista = dentistaCreateDto.NomeDentista,
                Especialidade = dentistaCreateDto.Especialidade,
                TelefoneDentista = dentistaCreateDto.TelefoneDentista,
                EmailDentista = dentistaCreateDto.EmailDentista
            };

            _repository.AdicionarDentista(dentista);

            return CreatedAtAction(nameof(Get), new { id = dentista.DentistaId }, dentista);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] DentistaCreateDTO dentistaCreateDto)
        {
            if (dentistaCreateDto == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var dentistaExistente = _repository.ObterPorId(id);

            if (dentistaExistente == null)
            {
                return NotFound("Dentista não encontrado para alteração.");
            }

            dentistaExistente.NomeDentista = dentistaCreateDto.NomeDentista;
            dentistaExistente.Especialidade = dentistaCreateDto.Especialidade;
            dentistaExistente.TelefoneDentista = dentistaCreateDto.TelefoneDentista;
            dentistaExistente.EmailDentista = dentistaCreateDto.EmailDentista;

            _repository.AtualizarDentista(dentistaExistente);
            return NoContent();
        }
    }
}
