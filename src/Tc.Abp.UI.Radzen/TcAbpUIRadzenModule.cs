using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Tc.Abp.UI;
[DependsOn(typeof(TcAbpUIModule))]
    public class TcAbpUIRadzenModule:AbpModule
    {
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddScoped<DialogService>();
        context.Services.AddScoped<NotificationService>();
        context.Services.AddScoped<TooltipService>();
        context.Services.AddScoped<ContextMenuService>();
        Configure<AbpRouterOptions>(options =>
        {
            options.AppAssembly = typeof(TcAbpUIRadzenModule).Assembly;
        });
    }
}
