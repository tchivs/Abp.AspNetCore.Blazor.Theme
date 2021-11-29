using Microsoft.Extensions.DependencyInjection;
using DemoApp.Blazor.Menus;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap;
using Tchivs.Abp.AspNetCore.Blazor.Theme;

namespace DemoApp.Blazor
{
    [DependsOn(
        typeof(DemoAppApplicationContractsModule),
        typeof(AbpAspNetCoreBlazorThemeBootstrapModule),
        typeof(AbpAutoMapperModule)
        )]
    public class DemoAppBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<DemoAppBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<DemoAppBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DemoAppMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(DemoAppBlazorModule).Assembly);
            });
        }
    }
}