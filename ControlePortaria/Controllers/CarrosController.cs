using ControlePortaria.Models;
using ControlePortaria.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControlePortaria.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ICarroRepository _carroRepository;

        public CarrosController(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public IActionResult List()
        {
            var carros = _carroRepository.Carros;
            return View(carros);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("CarroPlaca,CarroModelo,CarroKilometragem,Fabricante")] Carro carro)
        {
            if(ModelState.IsValid) {
                if (!_carroRepository.VerificarPlacaDuplicada(carro.CarroID, carro.CarroPlaca.ToUpper()))
                {
                    _carroRepository.Create(carro);
                    return RedirectToAction("List");

                }
                else
                {
                    ViewData["PlacaDuplicada"] = "Placa ja existe no banco de dados";
                    return View(carro);
                }
            }
            return View(carro);

        }

    }
}
