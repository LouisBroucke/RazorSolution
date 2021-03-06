﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorProject.Models
{
    public class Persoon
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public int Score { get; set; }

        [DisplayFormat(DataFormatString = "{0:€ #,##0.00}")]
        public decimal Wedde { get; set; }

        [DataType(DataType.Password)]
        public string Paswoord { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode=true)]
        public DateTime Geboren { get; set; }
        public bool Gehuwd { get; set; }
        public string Opmerkingen { get; set; }
        public Geslacht Geslacht { get; set; }    
    }
}
