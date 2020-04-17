﻿using System;
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
        
        public IActionResult Opslag()
        {
            OpslagViewModel opslagViewModel = new OpslagViewModel();
            opslagViewModel.Percentage = 10;
            return View(opslagViewModel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Opslag(OpslagViewModel opslagViewModel)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Opslag(opslagViewModel.VanWedde.Value, opslagViewModel.TotWedde.Value, opslagViewModel.Percentage);
                return RedirectToAction("Index");
            } else
            {
                return View(opslagViewModel);
            }
            
        }

        [HttpGet]
        public IActionResult VanTotWedde()
        {
            var form = new VanTotWeddeViewModel();
            return View(form);
        }

        [HttpGet]
        public IActionResult VanTotWeddeResultaat(VanTotWeddeViewModel form)
        {
            if (this.ModelState.IsValid)
            {
                form.Personen = _persoonService.VanTotWedde(form.VanWedde.Value, form.TotWedde.Value);
            }

            return View("VanTotWedde", form);
        }

        [HttpGet]
        public IActionResult Toevoegen()
        {
            var persoon = new Persoon();
            persoon.Score = 1;
            return View(persoon);
        }

        [HttpPost]
        public IActionResult Toevoegen(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Add(p);
                return RedirectToAction("Index");
            } else
            {
                return View(p);
            }
        }
    }
}