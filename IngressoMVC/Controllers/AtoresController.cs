using IngressoMVC.Data;
using IngressoMVC.Models;
using IngressoMVC.Models.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Controllers
{
    public class AtoresController : Controller
    { 
        private IngressoDbContext _context;

        public AtoresController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Atores);
        }

        public IActionResult Detalhes(int id)
        {
            var result = _context.Atores.Find(id);
            return View(result);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar([Bind("Nome,Bio,FotoPerfilURL")] PostAtorDTO atorDto)
        {
            //validar os dados
            Ator ator = new Ator(atorDto.Nome, atorDto.Bio, atorDto.FotoPerfilURL);
            //gravar esse ator no banco de dados
            _context.Atores.Add(ator);

            //salva ras mudanças
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar(int id)
        {
            //buscar ator no banco
            //passar o ator na view
            return View();
        }

        public IActionResult Deletar(int id)
        {
            //buscar ator no banco
            //passar o ator na view
            return View();
        }

    }
}
