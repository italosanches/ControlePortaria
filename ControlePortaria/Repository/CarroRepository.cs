using ControlePortaria.Context;
using ControlePortaria.Models;
using ControlePortaria.Models.Enums;
using ControlePortaria.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Carro> Carros => _context.Carros.AsNoTracking().ToArray();

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
            return Carros.FirstOrDefault(x => x.CarroId == id);
        }

        public void Update(Carro carro)
        {
            try
            {
                _context.Update(carro);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {

                throw new DbUpdateException("Erro ao atualizar cadastro");
            }
            catch(Exception) 
            {
                throw new Exception();
            }
            
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
                if (carro.CarroId == id)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

        public IEnumerable<Carro> CarrosDisponiveis() 
        {
            var carrosDisponiveis = _context.Carros.AsNoTracking().Where(c => c.CarroDisponivel);
            var portariaExistentes = _context.Portarias.AsNoTracking().Any();

            if(portariaExistentes) 
            {
                return carrosDisponiveis.AsNoTracking().Where(p => !_context.Portarias.Any(pt => p.CarroId == pt.CarroId && pt.PortariaStatus == PortariaStatus.PortariaAberta)).ToList();
                
            }
            return carrosDisponiveis;
        }

    }
}

