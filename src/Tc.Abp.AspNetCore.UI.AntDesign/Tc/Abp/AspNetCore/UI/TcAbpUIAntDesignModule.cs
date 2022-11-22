using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Tc.Abp.AspNetCore.UI;
    [DependsOn(typeof(TcAbpAspNetCoreModule))]
    public class TcAbpAspNetCoreUIAntDesignModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAntDesign();
            Configure<AbpRouterOptions>(options =>
            {
                //options.AppAssembly = typeof(TcAbpUIAntDesignModule).Assembly;
            });
        }
    }
