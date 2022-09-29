using Tc.Abp.UI;
using Volo.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.AspNetCore.Components.WebAssembly;
    [DependsOn(
typeof(TcAbpUIModule),
typeof(AbpHttpClientIdentityModelWebAssemblyModule),
typeof(AbpAspNetCoreComponentsWebAssemblyModule))]
    public class TcAbpAspNetCoreComponentsWebAssemblyModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(TcAbpAspNetCoreComponentsWebAssemblyModule).Assembly);
            });
        }
    }


