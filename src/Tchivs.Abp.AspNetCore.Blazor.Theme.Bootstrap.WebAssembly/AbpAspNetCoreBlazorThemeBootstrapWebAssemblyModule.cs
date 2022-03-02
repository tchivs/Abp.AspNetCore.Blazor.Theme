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
using Tchivs.Abp.AspNetCore.Blazor.Theme.WebAssembly;
using Volo.Abp.Bundling;
using Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly.Components;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.AspNetCore.Components.WebAssembly;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Bootstrap
{
    [DependsOn(
        typeof(AbpAspNetCoreBlazorThemeBootstrapModule)

    )]

    public class AbpAspNetCoreBlazorThemeBootstrapWebAssemblyModule : AbpAspNetCoreBlazorThemeWebAssemblyModuleBase<BlazorGlobalContributor>
    {
        protected override IToolbarContributor? GetToolbarContributor()
        {
            return new ToolbarContributor();
        }
    }
}