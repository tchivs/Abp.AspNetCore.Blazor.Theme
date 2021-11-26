﻿using Microsoft.Extensions.DependencyInjection;
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
using Abp.AspNetCore.Blazor.Theme.Bootstrap.WebAssembly.Components;

namespace Abp.AspNetCore.Blazor.Theme.Bootstrap
{
    [DependsOn(
        typeof(AbpAspNetCoreBlazorThemeBootstrapModule)
    )]
    public class AbpAspNetCoreBlazorThemeBootstrapWebAssemblyModule : AbpAspNetCoreBlazorThemeWebAssemblyModuleBase<BlazorGlobalContributor>
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
}