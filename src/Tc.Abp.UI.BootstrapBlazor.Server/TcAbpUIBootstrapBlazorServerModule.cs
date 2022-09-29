using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.AspNetCore.Components.Server;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace Tc.Abp.UI.BootstrapBlazor.Server
{
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
                    .Add(BlazorStandardBundles.Styles.Global, bundle =>
                    {
                        bundle.AddContributors(typeof(BootstrapBlazorStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(BlazorStandardBundles.Scripts.Global, bundle =>
                    {
                        bundle.AddContributors(typeof(BootstrapBlazorScriptContributor));
                    });
            });
        }
    }
}
