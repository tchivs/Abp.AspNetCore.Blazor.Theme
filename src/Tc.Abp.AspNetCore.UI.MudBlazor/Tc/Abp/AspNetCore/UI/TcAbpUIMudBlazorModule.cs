using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Tc.Abp.AspNetCore.UI;
[DependsOn(typeof(TcAbpAspNetCoreModule))]
public class TcAbpUIMudBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMudServices();
        Configure<AbpRouterOptions>(options =>
        {
            //  options.AppAssembly = typeof(TcAbpUIMudBlazorModule).Assembly;
        });
    }
}
