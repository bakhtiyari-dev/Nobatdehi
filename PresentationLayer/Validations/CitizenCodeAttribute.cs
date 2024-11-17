using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Validations
{
    public class CitizenCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {            
            if (value == null)
            {
                return new ValidationResult("Pleas Submit Currect Citizen Code");
            }

            string citizenCode = value.ToString();

            if (citizenCode.StartsWith("9") && citizenCode.Length == 10)
            {
                return ValidationResult.Success;
            }

            if (citizenCode.Length == 12)
            {
                return ValidationResult.Success;
            }

            if (citizenCode.Length >= 6 && citizenCode.Length <= 12)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Pleas Submit Currect Citizen Code");
        }
    }
}
