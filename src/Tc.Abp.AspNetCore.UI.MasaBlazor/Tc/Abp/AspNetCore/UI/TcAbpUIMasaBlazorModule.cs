using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Tc.Abp.AspNetCore.UI;
[DependsOn(typeof(TcAbpAspNetCoreModule))]
public class TcAbpUIMasaBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMasaBlazor();
        Configure<AbpRouterOptions>(options =>
        {
            //  options.AppAssembly = typeof(TcAbpUIMasaBlazorModule).Assembly;
        });
    }
}
