using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Data;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();
            //EnsureDatabaseCreation(host.Services);
            //SeedData.EnsureSeedData(host.Services);
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //private static void EnsureDatabaseCreation(IServiceProvider services)
        //{
        //    using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        //    {
        //        scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
        //        scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
        //        scope.ServiceProvider.GetService<ApplicationDbContext>().Database.Migrate();
        //    }
        //}
    }
}
