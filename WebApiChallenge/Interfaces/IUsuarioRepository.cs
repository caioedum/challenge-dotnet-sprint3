using WebApiChallenge.Models;

namespace WebApiChallenge.Interfaces
{
    public interface IUsuarioRepository
    {
        public List<Usuario> ObterTodos();
        public Usuario? ObterPorId(int usuarioId);
        public void AdicionarUsuario(Usuario usuario);
        public void AtualizarUsuario(Usuario usuario);
    }
}
