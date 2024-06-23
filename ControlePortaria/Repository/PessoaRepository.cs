using ControlePortaria.Context;
using ControlePortaria.Models;
using ControlePortaria.Models.Enums;
using ControlePortaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
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
            return _context.Pessoas.FirstOrDefault(x => x.PessoaId == Pessoaid);

        }

        public void Create(Pessoa pessoa)
        {
            try
            {
                _context.Pessoas.Add
                    (new Pessoa(pessoa.PessoaNome, pessoa.PessoaTelefone, pessoa.PessoaStatus));
               _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Pessoa pessoa)
        {
            try
            {
                _context.Update(pessoa);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {

                throw new DbUpdateException("Erro ao fazer a atualização. Tente novamente");
            }
            catch(Exception) 
            {
                throw new Exception();
            }
           
        }
        public Pessoa Edit(int id)
        {
            var pessoa = GetPessoaById(id);

            return pessoa;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void InativarPessoa(int id)
        {
            var pessoa = GetPessoaById(id);
            pessoa.PessoaStatus = PessoaStatus.Inativo;
            try
            {
                _context.Update(pessoa);
                _context.SaveChanges();
            }
            catch(DbUpdateException) 
            {
                throw new DbUpdateException();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

       
    }
}
