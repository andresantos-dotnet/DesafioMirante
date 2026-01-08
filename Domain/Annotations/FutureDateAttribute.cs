using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Annotations
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public FutureDateAttribute()
        {
            ErrorMessage = "A data deve ser superior a atual.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime date)
            {
                // Compara apenas a data (sem horas)
                if (date.Date <= DateTime.Now.Date)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
