using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DesafioPV.Infra
{
    public class ConnectionNH
    {

        private static string ConnectionString = "Server=localhost;Port=3306;Database=desafiopv;Uid=root;Pwd=;";
        private static ISessionFactory session;

        public static ISessionFactory CreateSession()
        {
            if (session != null)
            {
                return session;
            }

            
            
            IPersistenceConfigurer dbConfig = MySQLConfiguration.Standard.ConnectionString(ConnectionString);

            var mapConfig = Fluently.Configure().Database(dbConfig).Mappings(c => c.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()));

            mapConfig.ExposeConfiguration(BuildSchema);
            session = mapConfig.BuildSessionFactory();

            return session;
        }

        private static void BuildSchema(Configuration config)
        {
            //Creates database structure
            new SchemaExport(config)
               .Create(false, true);
        }

        public static ISession StartSession()
        {
            return CreateSession().OpenSession();
        }

    }
}
