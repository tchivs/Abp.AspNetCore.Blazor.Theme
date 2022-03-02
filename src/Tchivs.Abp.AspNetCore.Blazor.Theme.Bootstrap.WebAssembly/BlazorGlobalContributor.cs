using Volo.Abp.Bundling;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap
{
    public class BlazorGlobalContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
            context.Add("_content/Microsoft.AspNetCore.Components.WebAssembly.Authentication/AuthenticationService.js");
            context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
            context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/lang-utils.js");
            context.Add("_content/BootstrapBlazor/js/bootstrap.blazor.bundle.min.js");
        }

        public void AddStyles(BundleContext context)
        {
            var name = "Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly";
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
            context.Add($"_content/{typeof(AbpAspNetCoreBlazorThemeBootstrapModule).Namespace}/css/site.css");

        }
    }
}