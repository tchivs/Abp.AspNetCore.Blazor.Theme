using Microsoft.JSInterop;
using Volo.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.AutoMapper;
using Volo.Abp.Bundling;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.WebAssembly
{
    [DependsOn(
         typeof(AbpAspNetCoreBlazorThemeModule),
     typeof(AbpHttpClientIdentityModelWebAssemblyModule),
         typeof(AbpAspNetCoreComponentsWebAssemblyModule)
     )]
    public abstract class AbpAspNetCoreBlazorThemeWebAssemblyModuleBase<TBundleContributor> : AbpModule
         where TBundleContributor : IBundleContributor
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpToolbarOptions>(options =>
            {
                var t = GetToolbarContributor();
                if (t != null)
                {
                    options.Contributors.Add(t);
                }
            });
            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(Pages.Authentication).Assembly);
            });
            
        }

        protected abstract IToolbarContributor? GetToolbarContributor();
    }
}