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
        public decimal VanWedde { get; set; }

        [Display(Name = "Tot wedde: ")]
        public decimal TotWedde { get; set; }

        [Display(Name = "Percentage: ")]
        public decimal Percentage { get; set; }
    }
}
