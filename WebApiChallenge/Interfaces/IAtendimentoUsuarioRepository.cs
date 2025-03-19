using WebApiChallenge.Models;

namespace WebApiChallenge.Interfaces
{
    public interface IAtendimentoUsuarioRepository
    {
        public List<AtendimentoUsuario> ObterTodos();
        public AtendimentoUsuario? ObterPorId(int atendimentoId);
        public bool VerificarUsuarioPorId(int usuarioId);
        public bool VerificarDentistaPorId(int dentistaId);
        public bool VerificarClinicaPorId(int clinicaId);
        public void AdicionarAtendimento(AtendimentoUsuario atendimento);
        public void AtualizarAtendimento(AtendimentoUsuario atendimento);
        public void DeletarAtendimento(int atendimentoId);
    }
}
