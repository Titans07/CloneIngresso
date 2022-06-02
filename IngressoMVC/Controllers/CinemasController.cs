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
    public class CinemasController : Controller
    {
        private IngressoDbContext _context;

        public CinemasController(IngressoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Cinemas);
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
        public IActionResult Criar(PostCinemaDTO cinemaDto)
        {
            Cinema cinema = new Cinema(cinemaDto.Nome, cinemaDto.LogoURL, cinemaDto.Descricao);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atualizar()
        {
            return View();
        }

    }
}
