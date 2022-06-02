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
    public class ProdutoresController : Controller
    {
        private IngressoDbContext _context;

        public ProdutoresController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Produtores);
        }

        public IActionResult Detalhes()
        {
            return View();
        }

        public IActionResult Deletar()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(PostProdutorDTO produtorDto)
        {
            Produtor produtor = new Produtor(produtorDto.Nome, produtorDto.Bio, produtorDto.FotoPerfilURL);

            _context.Produtores.Add(produtor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar()
        {
            return View();
        }
    }
}
