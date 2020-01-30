using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using webapi.Infra.Data.Context;

namespace webapi.Infra.Data.Providers
{
    public class ContextProvider : Provider<LibraryContext>
    {

        private ConnectionStringSettings ConnectionString { get; set; }

        private static LibraryContext Context { get; set; }


        public ContextProvider(ConnectionStringSettings connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override LibraryContext CreateInstance(IContext context)
        {optionsBuilder
    .UseSqlServer(connectionString, providerOptions=>providerOptions.CommandTimeout(60))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            Context = new LibraryContext(ConnectionString.Name);

            return Context;
        }


    }
}
