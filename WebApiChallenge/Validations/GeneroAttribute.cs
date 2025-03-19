using System.ComponentModel.DataAnnotations;

namespace WebApiChallenge.Validations
{
    public class GeneroAttribute : ValidationAttribute
    {
        private readonly string[] _allowedValues;

        public GeneroAttribute(params string[] allowedValues)
        {
            _allowedValues = allowedValues;
            ErrorMessage = $"O gênero deve ser um dos seguintes valores: {string.Join(", ", allowedValues)}";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("O gênero é obrigatório.");

            var genero = value?.ToString()?.ToUpper();

            if (genero == null || !_allowedValues.Contains(genero))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
