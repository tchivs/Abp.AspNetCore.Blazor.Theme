using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.AspNetCore.Components.Server;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;

namespace Tc.Abp.UI.AntDesign.Server
{
    [DependsOn(typeof(TcAbpUIAntDesignModule),
        typeof(TcAbpAspNetCoreComponentsServerModule))]
    public class TcAbpUIAntDesignServerModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(BlazorStandardBundles.Styles.Global, bundle =>
                    {
                        bundle.AddContributors(typeof(AntDesignStyleContributor));
                    });

                options
                    .ScriptBundles
                    .Add(BlazorStandardBundles.Scripts.Global, bundle =>
                    {
                        bundle.AddContributors(typeof(AntDesignScriptContributor));
                    });
            });
        }
    }
}
