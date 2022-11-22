using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.AspNetCore.Components;
using Volo.Abp.Modularity;
namespace Tc.Abp.AspNetCore.UI;

[DependsOn(typeof(TcAbpAspNetCoreModule))]
public class TcAbpUIBootstrapBlazorModule:AbpModule
    {
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AppType = typeof(BootstrapApp);
            options.DefaultLayout = typeof(BootstrapMainLayout);

        });
        context.Services.AddBootstrapBlazor();
      
    }
}
