using ControlePortaria.Models;
using ControlePortaria.ViewModel;

namespace ControlePortaria.Repository.Interfaces
{
    public interface IPortariaRepository
    {
        IEnumerable<Portaria> Portarias { get; }

        Portaria GetPortariaById(int Pessoaid);
        public void Create(PortariaViewModel portaria);

        public void Update(Portaria portaria);

        public Pessoa Edit(int id);

        public void RegistrarChegada(int id);

       
    }
}
