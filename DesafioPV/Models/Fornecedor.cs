using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioPV.Models
{
    public class Fornecedor
    {
        public virtual int ID { get; set; }


        public virtual string Nome { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public virtual string CpfCnpj { get; set; }

        [Display(Name = "RG")]
        public virtual string Rg { get; set; }

        [Display(Name = "Data e hora de cadastro")]
        public virtual DateTime DtHoraCadastro { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [CustomValidationAge(ErrorMessage = "Para o Paraná, são aceitos apenas fornecedores maiores de idade")]
        public virtual DateTime DtNascimento { get; set; }

        public virtual Empresa Empresa{get; set;}

        public virtual IList<TelefoneFornecedor> ListaTelefoneFornecedor { get; set; }

        public virtual string UfEmpresa { get; set; }

    }

   

}
