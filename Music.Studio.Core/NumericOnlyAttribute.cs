using System.ComponentModel.DataAnnotations;

namespace Music.Studio.Core;

public class NumericOnlyAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (int.TryParse(value.ToString(), out int result))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("El campo debe ser un número entero.");
    }
}