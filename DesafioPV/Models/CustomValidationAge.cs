using DesafioPV.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPV.Models
{
    public class CustomValidationAge : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var fornecedor = (Models.Fornecedor) validationContext.ObjectInstance;

            if (fornecedor.DtNascimento != null && fornecedor.Empresa != null && fornecedor.Empresa.UF == "PR")
            {
                if (Utils.GetAge(value) < 18)
                {

                    return new ValidationResult
                        ("Para o Paraná, são aceitos apenas fornecedores maiores de idade.");
                }
            }

            return ValidationResult.Success;
        }

    }
}
