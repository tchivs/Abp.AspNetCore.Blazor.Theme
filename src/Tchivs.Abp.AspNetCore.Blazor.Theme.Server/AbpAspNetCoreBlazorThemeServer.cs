using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Components.Server;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.AspNetCore.Blazor.Theme.Server
{

    [DependsOn(
       typeof(AbpAspNetCoreBlazorThemeModule),
   typeof(AbpAspNetCoreComponentsServerModule),
   typeof(AbpAspNetCoreMvcUiPackagesModule),
   typeof(AbpAspNetCoreMvcUiBundlingModule)
   )]
    public abstract class AbpAspNetCoreBlazorThemeServerModuleBase<TStyleBundleContributor, TScriptBundleContributor> : AbpModule
        where TStyleBundleContributor : BundleContributor
       where TScriptBundleContributor : BundleContributor
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpToolbarOptions>(options =>
            {
                var toobar = GetToolbarContributor();
                if (toobar != null)
                {
                    options.Contributors.Add(toobar);

                }
            });
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(BlazorThemeBundles.Styles.Global,
                        bundle => { bundle.AddContributors(typeof(TStyleBundleContributor)); });

                options
                    .ScriptBundles
                    .Add(BlazorThemeBundles.Scripts.Global,
                        bundle => { bundle.AddContributors(typeof(TScriptBundleContributor)); });
            });
        }
        protected abstract IToolbarContributor? GetToolbarContributor();
    }
}