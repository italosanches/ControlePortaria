using ControlePortaria.Models.Enums;
using ControlePortaria.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControlePortaria.Controllers
{
    public class PortariaController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ICarroRepository _carroRepository;

        public PortariaController(IPessoaRepository pessoaRepository, ICarroRepository carroRepository)
        {
            _pessoaRepository = pessoaRepository;
            _carroRepository = carroRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.PessoasAtivas = _pessoaRepository.Pessoas.Where(pessoa => pessoa.PessoaStatus == PessoaStatus.Ativado);
            Console.WriteLine(ViewBag.PessoasAtivas);
            ViewBag.CarrosDisponiveis = _carroRepository.Carros.Where(carro => carro.CarroDisponivel);
            return View();
        }
    }
}
