using ControlePortaria.Context;
using ControlePortaria.Models;
using ControlePortaria.Repository.Interfaces;
using System.Net.WebSockets;

namespace ControlePortaria.Repository
{
    public class CarroRepository : ICarroRepository

    {
        private readonly AppDbContext _context;
        public CarroRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Carro> Carros => _context.Carros.ToArray();

        public void Create(Carro carro)
        {
            try
            {
                _context.Carros.Add(new Carro(carro.CarroPlaca, carro.CarroModelo, carro.CarroKilometragem, carro.Fabricante));
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

        public Carro GetCarroById(int id)
        {
            return Carros.FirstOrDefault(x => x.CarroID == id);
        }

        public void Update(Carro carro)
        {
            throw new NotImplementedException();
        }

        public bool VerificarPlacaDuplicada(int id, string placa)
        {
            var carro = Carros.FirstOrDefault(x => x.CarroPlaca == placa);

            if (carro == null)
            {
                return false;
            }
            else
            {
                if (carro.CarroID == id)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

    }
}

