using Domain.Interfaces.Churrasco;
using Domain.Interfaces.Usuario;
using Microsoft.Extensions.DependencyInjection;
using Services.Services.Churrasco;
using Services.Services.Usuario;

namespace CrossCutting.DependencyInjector
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUsuarioAppService, UsuarioAppService>();
            serviceCollection.AddTransient<IChurrascoAppService, ChurrascoAppService>();
            
        }
    }
}