using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCihaziUretimPlanlama.Core.Interfaces;
using TestCihaziUretimPlanlama.Core.Interfaces.Repositories;
using TestCihaziUretimPlanlama.Core.Interfaces.Services;
using TestCihaziUretimPlanlama.Infrastructure.Data;
using TestCihaziUretimPlanlama.Infrastructure.Repositories;
using TestCihaziUretimPlanlama.Infrastructure.Services;

namespace TestCihaziUretimPlanlama.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // PostgreSQL Legacy Timestamp Behavior'ı etkinleştir
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Database
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies(); // Lazy loading aktifleştir
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                {
                    options.EnableSensitiveDataLogging(); // Development için
                    options.EnableDetailedErrors();
                }
            });

            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDepartmanRepository, DepartmanRepository>();
            services.AddScoped<IPersonelRepository, PersonelRepository>();
            services.AddScoped<IGorevRepository, GorevRepository>();
            services.AddScoped<ISiparisRepository, SiparisRepository>();
            services.AddScoped<IUretimGoreviRepository, UretimGoreviRepository>();
            services.AddScoped<IKategoriRepository, KategoriRepository>();
            // Services
            services.AddScoped<IVardiyaService, VardiyaService>();
            services.AddScoped<IGorevService, GorevService>();
            services.AddScoped<ISiparisService, SiparisService>();
            services.AddScoped<IPlanlamaService, PlanlamaService>();
            // Repositories
           

      

            return services;
        }
    }
}
