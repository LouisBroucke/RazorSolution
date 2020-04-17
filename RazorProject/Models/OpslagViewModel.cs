using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorProject.Models
{
    public class OpslagViewModel
    {
        [Display(Name = "Van wedde: ")]
        [Required(ErrorMessage = "Van wedde is een verplicht veld")]
        public decimal? VanWedde { get; set; }

        [Display(Name = "Tot wedde: ")]
        [Required(ErrorMessage = "Van wedde is een verplicht veld")]
        public decimal? TotWedde { get; set; }

        [Display(Name = "Percentage: ")]
        [Range(0,100,ErrorMessage = "De minimum en maximumwaarden voor percentage zijn: {1} en {2}")]
        public decimal Percentage { get; set; }
    }
}
