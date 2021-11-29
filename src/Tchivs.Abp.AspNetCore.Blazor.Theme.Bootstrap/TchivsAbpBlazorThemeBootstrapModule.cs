using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore;
using Tchivs.Abp.AspNetCore.Blazor.Theme;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap
{
    [DependsOn(typeof(AbpAspNetCoreBlazorThemeModule))]
    public class AbpAspNetCoreBlazorThemeBootstrapModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AbpAspNetCoreBlazorThemeBootstrapModule).Assembly);
            });
            context.Services.AddAuthorizationCore();
            context.Services.AddBootstrapBlazor();
        }
    }
}