using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorProject.Models;
using RazorProject.Services;

namespace RazorProject.Controllers
{
    public class PersoonController : Controller
    {
        private PersoonService _persoonService;

        public PersoonController(PersoonService persoonService)
        {
            _persoonService = persoonService;
        }
        public IActionResult Index()
        {
            return View(_persoonService.FindAll());
        }

        [HttpGet]
        public IActionResult VerwijderForm(int id)
        {
            return View(_persoonService.FindById(id));
        }

        [HttpPost]
        public IActionResult Verwijderen(int id)
        {
            _persoonService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new OpslagViewModel();
            return View(opslagViewModel);
        }
    }
}