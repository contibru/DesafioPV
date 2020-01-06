
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioPV.Models
{
    public class Empresa
    {
        public virtual int ID { get; set; }

        [Display(Name ="Nome fantasia")]
        public virtual string NomeFantasia { get; set; }

        [Display(Name = "CNPJ")]
        public virtual string Cnpj { get; set; }

        [MaxLength(2)]
        public virtual string UF { set; get; }
               
        public virtual IList<Fornecedor> ListaFornecedor { get; set; }

    }
}
