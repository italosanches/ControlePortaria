using ControlePortaria.Models;

namespace ControlePortaria.Repository.Interfaces
{
    public interface ICarroRepository
    {
        IEnumerable<Carro> Carros { get; }
        public Carro GetCarroById(int id);

        public void Create(Carro carro);
        public void Update(Carro carro);
    }
}
