using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Validations
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {                
            if (value == null)
            {
                return new ValidationResult("Pleas Submit Currect Format For Phone Number");
            }

            string phoneNumber = value.ToString();

            if (phoneNumber.StartsWith("+98") && phoneNumber.Length == 13)
            {
                return ValidationResult.Success;
            }

            if (phoneNumber.StartsWith("09") && phoneNumber.Length == 11)
            {
                return ValidationResult.Success;
            }

            if (phoneNumber.StartsWith("9") && phoneNumber.Length == 10)
            {
                return ValidationResult.Success;
            }

            if (phoneNumber.StartsWith("+9800") && phoneNumber.Length == 13)
            {
                return new ValidationResult("Phone Number Not Start With +9800");
            }

            if (!phoneNumber.StartsWith("0900") && phoneNumber.Length == 13)
            {
                return new ValidationResult("Phone Number Not Start With 0900");
            }

            if (!phoneNumber.StartsWith("900") && phoneNumber.Length == 10)
            {
                return new ValidationResult("Phone Number Not Start With 900");
            }

            return new ValidationResult("Pleas Submit Currect Format For Phone Number");
        }
    }
}
