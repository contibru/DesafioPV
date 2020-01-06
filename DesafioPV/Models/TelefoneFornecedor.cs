using System;

namespace DesafioPV.Models
{
    public class TelefoneFornecedor
    {
        public virtual int ID { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public virtual string Telefone { get; set; }


    }
}
