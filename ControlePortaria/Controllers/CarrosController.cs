using ControlePortaria.Models;
using ControlePortaria.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (ModelState.IsValid)
            {
                try
                {
                    if (!_carroRepository.VerificarPlacaDuplicada(carro.CarroId, carro.CarroPlaca.ToUpper()))
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
                catch (Exception ex)
                {

                    ViewData["ErrorMessage"] = ex.Message;
                }

            }
            return View(carro);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_carroRepository.GetCarroById(id));
        }

        [HttpPost]
        public IActionResult Edit([Bind("CarroId,CarroPlaca,CarroModelo,CarroKilometragem,Fabricante")] Carro carro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!_carroRepository.VerificarPlacaDuplicada(carro.CarroId, carro.CarroPlaca.ToUpper()))
                    {
                        _carroRepository.Update(carro);
                        return RedirectToAction("List");
                    }
                    return View(carro);
                }
            }
            catch (DbUpdateException ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {

                ViewData["ErrorMessage"] = ex.Message;
            }
            return View(carro);

        }

    }
}
