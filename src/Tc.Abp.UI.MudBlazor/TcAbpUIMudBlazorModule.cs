using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.UI;
using Volo.Abp.Modularity;

namespace Tc.Abp.UI;
    [DependsOn(typeof(TcAbpUIModule))]
    public class TcAbpUIMudBlazorModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMudServices();
            Configure<AbpRouterOptions>(options =>
            {
                options.AppAssembly = typeof(TcAbpUIMudBlazorModule).Assembly;
            });
        }
    }
