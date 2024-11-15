using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Validations
{
    public class CitizenCodeTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Pleas Submit Currect Citizen Type Between : ( PASSPORT, EXCLUSIVE, UNIQ, FAMILY )");
            }

            string citizenCode = value.ToString();

            if (citizenCode.ToUpper() == "PASSPORT")
            {
                return ValidationResult.Success;
            }

            if (citizenCode.ToUpper() == "UNIQ")
            {
                return ValidationResult.Success;
            }

            if (citizenCode.ToUpper() == "EXCLUSIVE")
            {
                return ValidationResult.Success;
            }

            if (citizenCode.ToUpper() == "FAMILY")
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Pleas Submit Currect Citizen Type Between : ( PASSPORT, EXCLUSIVE, UNIQ, FAMILY )");
        }
    }
}