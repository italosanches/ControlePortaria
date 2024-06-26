using ControlePortaria.Models;


namespace ControlePortaria.Repository.Interfaces
{
    public interface IPortariaRepository
    {
        IEnumerable<Portaria> Portarias { get; }

        Portaria GetPortariaById(int Pessoaid);
        public void Create(Portaria portaria);

        public void Update(Portaria portaria);

        public Pessoa Edit(int id);

        public void RegistrarChegada(int id);

       
    }
}
