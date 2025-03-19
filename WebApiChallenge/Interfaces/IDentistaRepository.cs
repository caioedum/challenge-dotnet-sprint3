using WebApiChallenge.Models;

namespace WebApiChallenge.Interfaces
{
    public interface IDentistaRepository
    {
        public List<Dentista> ObterTodos();
        public Dentista? ObterPorId(int dentistaId);
        public void AdicionarDentista(Dentista dentista);
        public void AtualizarDentista(Dentista dentista);
    }
}
