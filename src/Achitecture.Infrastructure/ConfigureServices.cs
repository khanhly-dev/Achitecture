using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Achitecture.Infrastructure.Persistence.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Achitecture.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;
using Achitecture.Repository.Common.Interface;
using Achitecture.Infrastructure.Persistence.EntityFrameworkCore.CommonRepo;

namespace Achitecture.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ComputerStore"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ApplicationDbContextInitialiser>();
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddScoped(typeof(IBaseRepo<,>), typeof(BaseRepo<,>));
           
            return services;
        }
    }
}
