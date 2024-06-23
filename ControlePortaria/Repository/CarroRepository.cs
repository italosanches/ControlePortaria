using ControlePortaria.Context;
using ControlePortaria.Models;
using ControlePortaria.Repository.Interfaces;

namespace ControlePortaria.Repository
{
    public class CarroRepository : ICarroRespotory

    {
        private readonly AppDbContext _context;
        public CarroRepository(AppDbContext context)
        {
                _context = context;
        }
        public IEnumerable<Carro> Carros => _context.Carros.ToArray();

        public void Create(Carro carro)
        {
            _context.Carros.Add(carro);
            _context.SaveChanges();
        }

        public Carro GetCarroById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Carro carro)
        {
            throw new NotImplementedException();
        }
    }
}
