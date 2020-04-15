using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorProject.Models
{
    public class Filiaal
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        [UIHint("sterretjes")]
        public DateTime Gebouwd { get; set; }

        public decimal Waarde { get; set; }

        public Eigenaar eigenaar { get; set; }
    }
}
