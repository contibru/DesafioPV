using DesafioPV.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPV.Mapping
{
    public class FornecedorMap : ClassMap<Fornecedor>
    {

        public FornecedorMap()
        {
            Id(x => x.ID);
            Map(x => x.Nome);
            Map(x => x.CpfCnpj);
            Map(x => x.DtHoraCadastro);
            Table("Fornecedor");
            References(x => x.Empresa).Column("EmpresaID");
            HasMany(x => x.ListaTelefoneFornecedor).Table("TelefoneFornecedor");

        }



    }
}
