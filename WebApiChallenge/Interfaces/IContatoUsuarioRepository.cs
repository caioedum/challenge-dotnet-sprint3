using WebApiChallenge.Models;

namespace WebApiChallenge.Interfaces
{
    public interface IContatoUsuarioRepository
    {
        public List<ContatoUsuario> ObterTodos();
        public ContatoUsuario? ObterPorId(int contatoId);
        public bool VerificarUsuarioPorId(int usuarioId);
        public bool EmailJaCadastrado(string email);
        public bool TelefoneJaCadastrado(string telefone);
        public void AdicionarContato(ContatoUsuario contato);
        public void AtualizarContato(ContatoUsuario contato);
        public void DeletarContato(int contatoId);
    }
}
