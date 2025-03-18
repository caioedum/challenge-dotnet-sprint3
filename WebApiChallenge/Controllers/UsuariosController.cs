using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiChallenge.Context;
using WebApiChallenge.DTO;
using WebApiChallenge.Models;

namespace WebApiChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public UsuariosController(WebApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            if (_context.Usuarios is null)
            {
                return NotFound(); 
            }

            return _context.Usuarios.ToList();
        }

        [HttpGet("{id:int}", Name="GetUsuario")]
        public ActionResult<Usuario> Get(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return usuario;
        }

        [HttpPost]
        public ActionResult Post(UsuarioCreateDTO usuarioDto)
        {
            if (usuarioDto is null)
            {
                return BadRequest();
            }

            var usuario = new Usuario
            {
                Cpf = usuarioDto.Cpf,
                Nome = usuarioDto.Nome,
                Sobrenome = usuarioDto.Sobrenome,
                DataNascimento = usuarioDto.DataNascimento,
                Genero = usuarioDto.Genero,
                DataCadastro = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetUsuario",
                new { id = usuario.UsuarioId }, usuario);
        }

    }
}
