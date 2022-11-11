using System;
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
                            .AddFiles("/libs/bootstrap/css/bootstrap.css")
                            .AddContributors(typeof(RadzenStyleContributor));
                    });
                options
                    .ScriptBundles
                      .Add(BlazorRadzenThemeBundles.Scripts.Global, bundle =>
                      {
                          bundle
                              .AddBaseBundles(BlazorStandardBundles.Scripts.Global)
                              .AddFiles("/libs/bootstrap/js/bootstrap.bundle.js")
                              .AddContributors(typeof(RadzenScriptContributor));
                      });
            });
            Configure<BundleOptions>(options =>
            {
                options.Style = BlazorRadzenThemeBundles.Styles.Global;
                options.Script = BlazorRadzenThemeBundles.Scripts.Global;
            });
        }
    }
}
