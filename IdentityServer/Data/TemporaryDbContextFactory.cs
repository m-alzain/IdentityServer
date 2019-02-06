using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IdentityServer.Data
{
    /// <summary>
    /// From https://benjii.me/2017/05/enable-entity-framework-core-migrations-visual-studio-2017/
    /// </summary>
    public class TemporaryDbContextFactory
    {
        public class TemporaryDbContextIdentity : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();                

                var connection = configuration.GetConnectionString("DefaultConnection");

                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

                optionsBuilder.UseSqlServer(connection, sql => sql.MigrationsAssembly(migrationsAssembly));
                //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),sql => sql.MigrationsAssembly(migrationsAssembly));

                return new ApplicationDbContext(optionsBuilder.Options);
            }
        }

        public class TemporaryDbContextFactoryScopes : IDesignTimeDbContextFactory<PersistedGrantDbContext>
        {
            public PersistedGrantDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json")
                               .Build();
                var optionsBuilder = new DbContextOptionsBuilder<PersistedGrantDbContext>();
                var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                sql => sql.MigrationsAssembly(migrationsAssembly));

                return new PersistedGrantDbContext(optionsBuilder.Options, new OperationalStoreOptions());

            }
        }
        public class TemporaryDbContextFactoryOperational : IDesignTimeDbContextFactory<ConfigurationDbContext>
        {
            public ConfigurationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json")
                               .Build();
                var optionsBuilder = new DbContextOptionsBuilder<ConfigurationDbContext>();
                var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                sql => sql.MigrationsAssembly(migrationsAssembly));

                return new ConfigurationDbContext(optionsBuilder.Options, new ConfigurationStoreOptions());

            }
        }
    }
}