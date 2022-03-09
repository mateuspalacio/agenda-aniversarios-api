using Agenda.Models;

namespace Agenda.Repository
{
    public interface IPessoaRepository
    {
        public Task<Pessoa> CreatePessoa(Pessoa p);
        public Task<Pessoa> DeletePessoa(string nome);
        public Task<Pessoa> EditPessoa(Pessoa p);
        public Task<List<Pessoa>> GetPessoaDiaMes(int dia, int mes);
        public Task<List<Pessoa>> GetPessoaMes(int mes);
        public Task<List<Pessoa>> GetPessoaLetra(char letraInicial);
        public Task<List<Pessoa>> GetPessoasOrderedByNome();
        public Task<List<Pessoa>> GetPessoasOrderedByMes();


    }
}
