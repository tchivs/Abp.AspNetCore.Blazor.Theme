using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tc.Abp.AspNetCore.Components.Server;
using Tc.Abp.AspNetCore.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Tc.Abp.AspNetCore.UI.Server
{
    [DependsOn(typeof(TcAbpUIRadzenModule), 
        typeof(TcAbpAspNetCoreComponentsServerModule))]
    public class TcAbpUIRadzenServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
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
            ConfigureMenu(configuration);
        }
        private void ConfigureMenu(IConfiguration configuration)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DefaultMenuContributor(configuration));
            });

            //Configure<AbpToolbarOptions>(options =>
            //{
            //    options.Contributors.Add(new MyProjectNameToolbarContributor());
            //});
        }
    }
    internal class DefaultMenuContributor : BaseDefaultMenuContributor
    {
        public DefaultMenuContributor(IConfiguration configuration) : base(configuration)
        {
        }
        protected override ApplicationMenuItem CreateManageMenu(IStringLocalizer l, string authServerUrl)
        {
            var item= base.CreateManageMenu(l, authServerUrl);
            item.Icon = "manage_accounts";
            return item;
        }
        protected override ApplicationMenuItem CreateLogoutMenu(IStringLocalizer l)
        {
            var item =  base.CreateLogoutMenu(l);
            item.Icon = "logout";
            return item;
        }
    }
}
