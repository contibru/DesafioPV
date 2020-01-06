
using System;
using System.Collections.Generic;

namespace DesafioPV.Models
{
    public class Empresa
    {
        public virtual int ID { get; set; }
        public virtual string NomeFantasia { get; set; }
               
        public virtual string Cnpj { get; set; }
               
        public virtual string UF { set; get; }
               
        public virtual IList<Fornecedor> ListaFornecedor { get; set; }

    }
}
