using ControlePortaria.Models;

namespace ControlePortaria.Repository.Interfaces
{
    public interface ICarroRepository
    {
        IEnumerable<Carro> Carros { get; }
        public Carro GetCarroById(int id);

        public void Create(Carro carro);
        public void Edit(int id);
        public void Update(Carro carro);

        public bool VerificarPlacaDuplicada(int id,string placa);

    }
}
