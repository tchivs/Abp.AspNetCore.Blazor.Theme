using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore;
using Abp.AspNetCore.Blazor.Theme;
using Abp.AspNetCore.Blazor.Theme.WebAssembly;
using Volo.Abp.Bundling;

namespace Abp.AspNetCore.Blazor.Theme.Bootstrap
{
    [DependsOn(
        typeof(AbpAspNetCoreBlazorThemeBootstrapModule)
    )]
    public class AbpAspNetCoreBlazorThemeBootstrapWebAssemblyModule : AbpAspNetCoreBlazorThemeWebAssemblyModuleBase<BlazorGlobalContributor>
    {
        protected override IToolbarContributor? GetToolbarContributor()
        {
            return  null;
        }
    }
    public class BlazorGlobalContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
            context.Add("_content/Microsoft.AspNetCore.Components.WebAssembly.Authentication/AuthenticationService.js");
            context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
            context.Add("_content/BootstrapBlazor/js/bootstrap.blazor.bundle.min.js");
        }

        public void AddStyles(BundleContext context)
        {
            var name = this.GetType().Namespace;
            context.BundleDefinitions.Insert(0, new BundleDefinition
            {
                Source = $"_content/{name}/lib/fontawesome/css/all.css"
            });
            context.BundleDefinitions.Insert(1, new BundleDefinition
            {
                Source = $"_content/{name}/lib/fontawesome/css/v4-shims.css"
            });
            context.Add("_content/BootstrapBlazor/css/bootstrap.blazor.bundle.min.css");
            context.Add("_content/BootstrapBlazor/css/motronic.min.css");
            context.Add($"_content/{typeof(AbpAspNetCoreBlazorThemeModule).Namespace}/css/site.css");

        }
    }
}