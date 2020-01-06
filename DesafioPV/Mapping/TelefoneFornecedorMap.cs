using DesafioPV.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPV.Mapping
{
    public class TelefoneFornecedorMap : ClassMap<TelefoneFornecedor>
    {

        public TelefoneFornecedorMap()
        {
            Id(x => x.ID);
            Map(x => x.Telefone);
            Table("TelefoneFornecedor");
            References(x => x.Fornecedor).Column("FornecedorID");

        }



    }
}
