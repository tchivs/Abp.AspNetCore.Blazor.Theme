using System;
using System.Collections.Generic;
using System.Linq;

using Volo.Abp.AspNetCore.Components.Server;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages;
using Volo.Abp.Modularity;
using Tc.Abp.AspNetCore;
using Volo.Abp.UI.Navigation;
using Microsoft.Extensions.Configuration;
using Tc.Abp.AspNetCore.Toolbars;
using Microsoft.Extensions.DependencyInjection;

namespace Tc.Abp.AspNetCore.Components.Server;
[DependsOn(typeof(TcAbpAspNetCoreModule),
    typeof(AbpAspNetCoreComponentsServerModule),
    typeof(AbpAspNetCoreMvcUiPackagesModule),
    typeof(AbpAspNetCoreMvcUiBundlingModule))]
public class TcAbpAspNetCoreComponentsServerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //var configuration = context.Services.GetConfiguration();
        ConfigureBundles();
    }
    private void ConfigureBundles()
    {
        Configure<AbpBundlingOptions>(options =>
        {
            options
                .StyleBundles
                .Add(BlazorStandardBundles.Styles.Global, bundle =>
                {
                    bundle.AddContributors(typeof(BlazorGlobalStyleContributor));
                });
            options
                .ScriptBundles
                .Add(BlazorStandardBundles.Scripts.Global, bundle =>
                {
                    bundle.AddContributors(typeof(BlazorGlobalScriptContributor));
                });
        });

    }
 

}
