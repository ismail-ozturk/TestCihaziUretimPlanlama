using Microsoft.Extensions.DependencyInjection;
using TestCihaziUretimPlanlama.Application.Mappings;
using TestCihaziUretimPlanlama.Application.Services;
using TestCihaziUretimPlanlama.Application.Validators;

namespace TestCihaziUretimPlanlama.Application.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // Application Services - ApplicationDbContext'i de inject edin
            services.AddScoped<DepartmanAppService>();
            services.AddScoped<PersonelAppService>();
            services.AddScoped<GorevAppService>();
            services.AddScoped<SiparisAppService>();
            services.AddScoped<PlanlamaAppService>();
            services.AddScoped<KategoriAppService>();

            // Validators
            services.AddScoped<DepartmanCreateDtoValidator>();
            services.AddScoped<DepartmanUpdateDtoValidator>();
            services.AddScoped<PersonelCreateDtoValidator>();

            return services;
        }

    }
}
