using Tc.Abp.AspNetCore;
using Volo.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.AspNetCore.Components.WebAssembly;
    [DependsOn(
typeof(TcAbpAspNetCoreModule),
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


