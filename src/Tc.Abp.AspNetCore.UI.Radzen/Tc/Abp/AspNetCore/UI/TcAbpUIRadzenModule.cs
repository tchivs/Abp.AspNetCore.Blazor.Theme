using Microsoft.Extensions.DependencyInjection;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.AspNetCore.Components;
using Tc.Abp.AspNetCore.Toolbars;
using Volo.Abp.Modularity;

namespace Tc.Abp.AspNetCore.UI;
[DependsOn(typeof(TcAbpAspNetCoreModule))]
public class TcAbpUIRadzenModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddScoped<DialogService>();
        context.Services.AddScoped<NotificationService>();
        context.Services.AddScoped<TooltipService>();
        context.Services.AddScoped<ContextMenuService>();
        Configure<AbpToolbarOptions>(options =>
        {
            options.Contributors.Add(new RadzenThemeToolbarContributor());
        });
        Configure<AbpRouterOptions>(options =>
        {
            // options.AppAssembly = typeof(TcAbpUIRadzenModule).Assembly;
            options.DefaultLayout = typeof(MainLayout);
            options.HeaderStaticComponent = typeof(Tc.Abp.AspNetCore.Components.Theme);
        });
    }
}
