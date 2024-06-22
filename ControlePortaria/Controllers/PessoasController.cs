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
using ControlePortaria.Models.Enums;

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
        public IActionResult Create([Bind("PessoaNome,PessoaTelefone,PessoaStatus")] Pessoa pessoa) // bind = dados que a req ira mapear
        {
            try
            {
                if (ModelState.IsValid) // verifica se os dados estao validos
                {
                    _pessoaRepository.Create(pessoa);
                    return RedirectToAction("List"); // Redirecionar para a lista de pessoas após o cadastro
                }
            }
            catch (ArgumentNullException ex)
            {
               
               string mensagem = ex.Message;
                ViewData["ErrorMessage"] = mensagem;

            }
            return View("Create", pessoa);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var pessoa = _pessoaRepository.Edit(id);

            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Edit([Bind("PessoaNome,PessoaTelefone,PessoaId,PessoaStatus")] Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pessoaRepository.Update(pessoa);
     
                }
            }
            catch (Exception ex)
            {

                ViewData["ErrorMessage"] = ex.Message;
            }
           
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult InativarPessoa(int id)
        {
            _pessoaRepository.InativarPessoa(id);
            return RedirectToAction("List");
        }




    }
}
