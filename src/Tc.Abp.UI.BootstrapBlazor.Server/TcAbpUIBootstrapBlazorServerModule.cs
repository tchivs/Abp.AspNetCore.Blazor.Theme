﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.AspNetCore.Components.Server;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace Tc.Abp.UI.BootstrapBlazor.Server;
    [DependsOn(typeof(TcAbpUIBootstrapBlazorModule),
      typeof(TcAbpAspNetCoreComponentsServerModule))]
    public class TcAbpUIBootstrapBlazorServerModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options
                   .StyleBundles
                   .Add(BlazorBootstrapThemeBundles.Styles.Global, bundle =>
                   {
                       bundle
                           .AddBaseBundles(BlazorStandardBundles.Styles.Global)
                           .AddContributors(typeof(BootstrapBlazorStyleContributor));
                   });
                options
                    .ScriptBundles
                      .Add(BlazorBootstrapThemeBundles.Scripts.Global, bundle =>
                      {
                          bundle
                              .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                              .AddContributors(typeof(BootstrapBlazorScriptContributor));
                      });
            });
        Configure<AbpRouterOptions>(options =>
        {
            options.BundleStyle = BlazorStandardBundles.Styles.Global;
            options.BundleScript = BlazorStandardBundles.Scripts.Global;
        });
    }
      
    }
    public class BlazorBootstrapThemeBundles
    {
        public static class Styles
        {
            public static string Global = "Blazor.BootstrapTheme.Global";
        }

        public static class Scripts
        {
            public static string Global = "Blazor.BootstrapTheme.Global";
        }
    }
