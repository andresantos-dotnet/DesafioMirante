using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Annotations
{
    public class EnumValueAttribute<TEnum> : ValidationAttribute where TEnum : struct, Enum
    {
        public EnumValueAttribute()
        {
            ErrorMessage = $"Status inválido. Valores aceitos: {string.Join(", ", Enum.GetNames(typeof(TEnum)))}";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string str)
            {
                if (!Enum.TryParse<TEnum>(str, true, out _))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
