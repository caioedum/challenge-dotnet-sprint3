using WebApiChallenge.Models;

namespace WebApiChallenge.Interfaces
{
    public interface IPrevisaoRepository
    {
        public List<Previsao> ObterTodos();
        public Previsao? ObterPorId(int previsaoId);
        public bool VerificarImagemPorId(int imagemId);
        public bool VerificarUsuarioPorId(int usuarioId);
        public void AdicionarPrevisao(Previsao previsao);
        public void AtualizarPrevisao(Previsao previsao);
        public void DeletarPrevisao(int previsaoId);
    }
}
