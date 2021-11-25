using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace DemoApp
{
    [DependsOn(
        typeof(DemoAppApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class DemoAppHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "DemoApp";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(DemoAppApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
