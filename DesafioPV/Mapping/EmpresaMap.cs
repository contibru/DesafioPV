using DesafioPV.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioPV.Mapping
{
    public class EmpresaMap : ClassMap<Empresa>
    {

        public EmpresaMap()
        {
            Id(x => x.ID);
            Map(x => x.NomeFantasia);
            Map(x => x.Cnpj);
            Map(x => x.UF);
            Table("Empresa");
            HasMany(x => x.ListaFornecedor);

        }



    }
}
