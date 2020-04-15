using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RazorProject.Models;
using RazorProject.Services;

namespace RazorProject.Controllers
{
    public class HomeController : Controller
    {
        private FiliaalService _filiaalService;

        public HomeController(FiliaalService filiaalService)
        {
            _filiaalService = filiaalService;
        }

        public IActionResult Index()
        {
            return View(new Persoon { Voornaam = "Eddy", Familienaam = "Wally" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ActionName ("WerknemersLijst")]
        public IActionResult AlleWerknemers()
        {
            var werknemers = new List<Werknemer>();
            werknemers.Add(new Werknemer
            {
                Voornaam = "Steven",
                Wedde = 1000,
                InDienst = DateTime.Today
            });
            werknemers.Add(new Werknemer
            {
                Voornaam = "Prosper",
                Wedde = 2000,
                InDienst = DateTime.Today.AddDays(2)
            });

            return View("AlleWerknemers" ,werknemers);
        }

        public IActionResult Vestigingen()
        {
            Hoofdzetel deHoofdzetel = new Hoofdzetel
            {
                Straat = "Korte Veluwestraat",
                HuisNr = "6",
                PostCode = "2800",
                Gemeente = "Mechelen"
            };
            ViewBag.deHoofdzetel = deHoofdzetel;

            //List<Filiaal> filialen = new List<Filiaal>()
            //{
            //    new Filiaal { Id = 1, Naam = "Antwerpen", Gebouwd = new DateTime(2003, 1, 1), Waarde = 2000000, eigenaar = Eigenaar.Eigendom},
            //    new Filiaal { Id = 2, Naam = "Wondelgem", Gebouwd = new DateTime(1979, 1, 1), Waarde = 2500000, eigenaar = Eigenaar.Eigendom},
            //    new Filiaal { Id = 3, Naam = "Haasrode", Gebouwd = new DateTime(1976, 1, 1), Waarde = 1000000, eigenaar = Eigenaar.Gehuurd},
            //    new Filiaal { Id = 4, Naam = "Wevelgem", Gebouwd = new DateTime(1981, 1, 1), Waarde = 1600000, eigenaar = Eigenaar.Eigendom},
            //    new Filiaal { Id = 5, Naam = "Genk", Gebouwd = new DateTime(1990, 1, 1), Waarde = 4000000, eigenaar = Eigenaar.Gehuurd}
            //};

            return View(_filiaalService.FindAll());
        }

        public IActionResult Verwijderen(int id)
        {
            var filiaal = _filiaalService.Read(id);
            return View(filiaal);
        }

        public IActionResult Delete(int id)
        {
            var filiaal = _filiaalService.Read(id);
            this.TempData["filiaal"] = JsonConvert.SerializeObject(filiaal);
            _filiaalService.Delete(id);
            return Redirect("~/Home/Verwijderd");
        }

        public IActionResult Verwijderd()
        {
            var verwijderdFiliaal = (string)this.TempData["filiaal"]; 

            if (verwijderdFiliaal != null)
            {
                return View(JsonConvert.DeserializeObject<Filiaal>(verwijderdFiliaal));
            }
            else
            {
                return RedirectToAction("Vestigingen");
            }
        }  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
