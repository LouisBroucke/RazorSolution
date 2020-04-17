﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorProject.Models
{
    public class VanTotWeddeViewModel : IValidatableObject
    {
        [Display(Name = "Van wedde")]
        [Required(ErrorMessage = "Van wedde is verplicht")]
        public decimal? VanWedde { get; set; }

        [Display(Name = "Tot wedde")]
        [Required(ErrorMessage = "Tot wedde is verplicht")]
        public decimal? TotWedde { get; set; }

        public List<Persoon> Personen { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if (VanWedde > TotWedde)
            {
                validationResults.Add(new ValidationResult("VanWedde is groter dan TotWedde"));
            }

            return validationResults;
        }
    }
}