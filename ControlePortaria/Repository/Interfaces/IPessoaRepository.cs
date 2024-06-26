using ControlePortaria.Models;

namespace ControlePortaria.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> Pessoas { get; }

        Pessoa GetPessoaById(int Pessoaid);
        public void Create(Pessoa pessoa);

        public void Update(Pessoa pessoa);

        public Pessoa Edit(int id);

        public void Delete(int id);
        public void InativarPessoa(int id);

        public IEnumerable<Pessoa> PessoasDisponiveis();

	}
}
