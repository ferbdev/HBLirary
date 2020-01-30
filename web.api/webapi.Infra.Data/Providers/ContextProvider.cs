using Microsoft.EntityFrameworkCore;
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
        {
            //Context = new DbContext<LibraryContext>(options => options.us);

            return null;
        }


    }
}
