using WebApiChallenge.Models;

namespace WebApiChallenge.Interfaces
{
    public interface IClinicaRepository
    {
        public List<Clinica> ObterTodos();
        public Clinica? ObterPorId(int clinicaId);
        public void AdicionarUsuario(Clinica clinica);
        public void AtualizarUsuario(Clinica clinica);
    }
}
