using Microsoft.Extensions.DependencyInjection;
using PotentialCrud2.Domain.Interfaces.Services.Desenvolvedor;
using PotentialCrud2.Service.Services;

namespace PotentialCrud2.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDesenvolvedorService, DesenvolvedorService>();
        }
    }
}
