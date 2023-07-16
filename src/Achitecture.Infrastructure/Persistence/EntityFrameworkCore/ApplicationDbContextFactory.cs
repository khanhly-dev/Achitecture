using Achitecture.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Infrastructure.Persistence.EntityFrameworkCore
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var appsettingDirectory = Directory.GetCurrentDirectory().Replace("Infrastructure", "Api");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(appsettingDirectory)
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var connetionString = configuration.GetConnectionString("ComputerStore");

            var auditParem = new AuditableEntitySaveChangesInterceptor();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connetionString);
            return new ApplicationDbContext(optionsBuilder.Options, auditParem);
        }
    }
}
