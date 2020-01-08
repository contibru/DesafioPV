
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioPV.Models
{
    public class Empresa
    {
        public virtual int ID { get; set; }

        [Required]
        [Display(Name ="Nome fantasia")]
        public virtual string NomeFantasia { get; set; }

        [Required]
        [Display(Name = "CNPJ")]
        [CustomValidationCnpj()]
        public virtual string Cnpj { get; set; }

        [Required]
        [MaxLength(2)]
        public virtual string UF { set; get; }
               
        public virtual IList<Fornecedor> ListaFornecedor { get; set; }

    }
}
