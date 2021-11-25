using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace DemoApp
{
    [DependsOn(
        typeof(DemoAppHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class DemoAppConsoleApiClientModule : AbpModule
    {
        
    }
}
