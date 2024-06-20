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

        public IActionResult ListPessoas()
        {
            var pessoas = _pessoaRepository.Pessoas;
            return View(pessoas);
        }
        public IActionResult CreatePessoa()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Nome,Email,Telefone")] Pessoa pessoa)
        {

            return View(pessoa);
        }

    }
}
