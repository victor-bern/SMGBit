using Microsoft.Extensions.DependencyInjection;
using SMGBit.Application.Repositories;
using SMGBit.Application.Services;
using SMGBit.Domain.Interfaces;
using SMGBit.Domain.Repositories;

namespace SMGBit.Application.Extensions
{
    public static class ServicesExtesion
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFreteService, FreteService>();
            services.AddScoped<ITravelRepository, TravelRepository>();
        }
    }
}
