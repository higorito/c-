using System.ComponentModel.DataAnnotations;

namespace backendPicPay.Utils;

public class CpfCnpjValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var cpfCnpj = value as string;

        if (string.IsNullOrEmpty(cpfCnpj) || !CpfcnpjValidator.IsValidCpfCnpj(cpfCnpj))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}