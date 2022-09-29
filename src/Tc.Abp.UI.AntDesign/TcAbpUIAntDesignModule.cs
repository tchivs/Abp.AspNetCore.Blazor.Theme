using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.UI;
using Volo.Abp.Modularity;

namespace Tc.Abp.UI;
    [DependsOn(typeof(TcAbpUIModule))]
    public class TcAbpUIAntDesignModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAntDesign();
            Configure<AbpRouterOptions>(options =>
            {
                options.AppAssembly = typeof(TcAbpUIAntDesignModule).Assembly;
            });
        }
    }
