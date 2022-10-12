﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.AspNetCore.Components.Server;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace Tc.Abp.UI.Radzen.Server
{
    [DependsOn(typeof(TcAbpUIRadzenModule), typeof(TcAbpAspNetCoreComponentsServerModule))]
    public class TcAbpUIRadzenServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(BlazorRadzenThemeBundles.Styles.Global, bundle =>
                    {
                        bundle
                            .AddBaseBundles(BlazorStandardBundles.Styles.Global)
                            .AddContributors(typeof(RadzenStyleContributor));
                    });
                options
                    .ScriptBundles
                      .Add(BlazorRadzenThemeBundles.Scripts.Global, bundle =>
                      {
                          bundle
                              .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                              .AddContributors(typeof(RadzenScriptContributor));
                      });
            });
            Configure<AbpRouterOptions>(options =>
            {
                options.BundleStyle = BlazorRadzenThemeBundles.Styles.Global;
                options.BundleScript = BlazorRadzenThemeBundles.Scripts.Global;
            });
        }
    }
}
