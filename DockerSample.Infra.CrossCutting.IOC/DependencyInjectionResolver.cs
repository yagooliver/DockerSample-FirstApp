using DockerSample.Application.Implementation;
using DockerSample.Application.Interfaces;
using DockerSample.Domain.Contract;
using DockerSample.Domain.Contract.Repositories;
using DockerSample.Infra.Data;
using DockerSample.Infra.Data.Context;
using DockerSample.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DockerSample.Infra.CrossCutting.IOC
{
    public class DependencyInjectionResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<IPersonAppService, PersonAppService>();

            //Data
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DockerSampleContext>();
        }
    }
}
