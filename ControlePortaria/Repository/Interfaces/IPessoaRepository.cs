using ControlePortaria.Models;

namespace ControlePortaria.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> Pessoas { get; }

        Pessoa GetPessoaById(int Pessoaid);
        public void CreatePessoa(Pessoa pessoa);
        void Save();
    }
}
