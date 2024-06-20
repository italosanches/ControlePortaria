using ControlePortaria.Context;
using ControlePortaria.Models;
using ControlePortaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ControlePortaria.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDbContext _context;

        public PessoaRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Pessoa> Pessoas => _context.Pessoas.ToList();

        public Pessoa GetPessoaById(int Pessoaid)
        {
           return _context.Pessoas.FirstOrDefault(x=> x.PessoaId == Pessoaid);
            
        }

        public void Create(Pessoa pessoa) 
        { 
            _context.Pessoas.Add(pessoa);
            
        }
       
        public void Update(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }
        public Pessoa Edit(int id)
        {
            var pessoa = _context.Pessoas.FirstOrDefault(x => x.PessoaId == id);
            return pessoa;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();

        }

       
    }
}
