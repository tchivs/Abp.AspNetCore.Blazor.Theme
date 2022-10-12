using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.UI.Components;
using Volo.Abp.Modularity;

namespace Tc.Abp.UI;

[DependsOn(typeof(TcAbpUIModule))]
public class TcAbpUIBootstrapBlazorModule:AbpModule
    {
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AppType = typeof(BootstrapApp);
            options.AppAssembly = options.AppType.Assembly;
            options.DefaultLayout = typeof(BootstrapMainLayout);

        });
        context.Services.AddBootstrapBlazor();
      
    }
}
