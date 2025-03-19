using WebApiChallenge.Models;

namespace WebApiChallenge.Interfaces
{
    public interface IContatoUsuario
    {
        public List<ContatoUsuario> ObterTodos();
        public ContatoUsuario? ObterPorId(int contatoId);
        public bool VerificarUsuarioPorId(int usuarioId);
        public void AdicionarContato(ContatoUsuario contato);
        public void AtualizarContato(ContatoUsuario contato);
        public void DeletarContato(int contatoId);
    }
}
