using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlePortaria.Context;
using ControlePortaria.Models;
using ControlePortaria.Repository.Interfaces;
using ControlePortaria.Repository;

namespace ControlePortaria.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoasController(IPessoaRepository context)
        {
            _pessoaRepository = context;
        }

        public IActionResult List()
        {
            var pessoas = _pessoaRepository.Pessoas;
            return View(pessoas);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("PessoaNome,PessoaTelefone")] Pessoa pessoa) // bind = dados que a req ira mapear
        {


            if (ModelState.IsValid) // verifica se os dados estao validos
            {
                _pessoaRepository.Create(pessoa);
                _pessoaRepository.Save(); // Salvar alterações no banco de dados

                return RedirectToAction("ListPessoas"); // Redirecionar para a lista de pessoas após o cadastro
            }
            return View("CreatePessoa", pessoa);

        }

       

    }
}
