using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioPV.Models
{
    public class Fornecedor
    {
        public virtual int ID { get; set; }

        public virtual string Nome { get; set; }

        public virtual string CpfCnpj { get; set; }

        public virtual DateTime DtHoraCadastro { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime DtNascimento { get; set; }

        public virtual Empresa Empresa{get; set;}

        public virtual IList<TelefoneFornecedor> ListaTelefoneFornecedor { get; set; }

    }
}
