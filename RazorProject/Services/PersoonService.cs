using RazorProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorProject.Services
{
    public class PersoonService
    {
        private Dictionary<int, Persoon> personen = new Dictionary<int, Persoon>
        {
            {1, new Persoon{Id=1, Voornaam="Jesse", Familienaam="James", Score=5, Wedde=1000, Paswoord="123",
            Geboren= new DateTime(1966,1,1), Gehuwd=true, Opmerkingen="Schurk van het wilde westen", Geslacht=Geslacht.Man} },
            {2, new Persoon{Id=2, Voornaam="Jane", Familienaam="Calamity", Score=4, Wedde=2000, Paswoord="123",
            Geboren= new DateTime(1966,2,2), Gehuwd=true, Opmerkingen="Martha Jane Cannary", Geslacht=Geslacht.Vrouw} },
            {3, new Persoon{Id=3, Voornaam="Billy", Familienaam="The Kid", Score=5, Wedde=3000, Paswoord="123",
            Geboren= new DateTime(1966,3,3), Gehuwd=false, Opmerkingen="Revolverheld", Geslacht=Geslacht.Man} },
            {4, new Persoon{Id=4, Voornaam="Sarah", Familienaam="Bernhardt", Score=3, Wedde=4000, Paswoord="123",
            Geboren= new DateTime(1966,4,4), Gehuwd=false, Opmerkingen="Rosine Bernhardt", Geslacht=Geslacht.Vrouw} }
        };

        public List<Persoon> FindAll()
        {
            return personen.Values.ToList();
        }

        public Persoon FindById(int id)
        {
            return personen[id];
        }

        public void Delete(int id)
        {
            personen.Remove(id);
        }
    }
}
