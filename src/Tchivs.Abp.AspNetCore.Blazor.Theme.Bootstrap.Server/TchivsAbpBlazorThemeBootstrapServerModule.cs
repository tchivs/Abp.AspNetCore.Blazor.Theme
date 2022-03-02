using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.AspNetCore;
using Tchivs.Abp.AspNetCore.Blazor.Theme;
using Tchivs.Abp.AspNetCore.Blazor.Theme.Server;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.FontAwesome;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap
{

    [DependsOn(
        typeof(AbpAspNetCoreBlazorThemeBootstrapModule)
    )]
    public class AbpAspNetCoreBlazorThemeBootstrapServerModule : AbpAspNetCoreBlazorThemeServerModuleBase<BlazorGlobalStyleContributor, BlazorGlobalScriptContributor>
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
          
            base.ConfigureServices(context);
        }
        protected override IToolbarContributor? GetToolbarContributor()
        {
            return new ToolbarContributor();
        }
    }

    public class BlazorGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            
            context.Files.AddIfNotContains("/_framework/blazor.server.js");
            context.Files.AddIfNotContains("/_content/BootstrapBlazor/js/bootstrap.blazor.bundle.min.js");
            context.Files.AddIfNotContains("/_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
        }
    }

    //[DependsOn(
    //    typeof(FontAwesomeStyleContributor)
    //)]
    public class BlazorGlobalStyleContributor : BundleContributor
    {

        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_content/BootstrapBlazor/css/bootstrap.blazor.bundle.min.css");
            context.Files.AddIfNotContains("/_content/BootstrapBlazor/css/motronic.min.css");
            context.Files.AddIfNotContains($"/_content/Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap/css/site.css");

        }
    }
}