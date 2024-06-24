using ControlePortaria.Context;
using ControlePortaria.Models;
using ControlePortaria.Repository.Interfaces;
using ControlePortaria.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace ControlePortaria.Repository
{
    public class PortariaRepository : IPortariaRepository

    {
        private readonly AppDbContext _context;
        public PortariaRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Portaria> Portarias => _context.Portarias.AsNoTracking().ToArray();

        public void Create(PortariaViewModel portaria)
        {
            try
            {
                _context.Add(new Portaria(portaria.PessoaId, portaria.CarroId, portaria.HorarioSaida, portaria.Destino));
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Edit(int id)
        {
            throw new NotImplementedException();
        }

        public Portaria GetPortariaById(int Pessoaid)
        {
            throw new NotImplementedException();
        }

        public void RegistrarChegada(int id)
        {
            throw new NotImplementedException();
        }



        public void Update(Portaria portaria)
        {
            throw new NotImplementedException();
        }

        Pessoa IPortariaRepository.Edit(int id)
        {
            throw new NotImplementedException();
        }
    }
}

