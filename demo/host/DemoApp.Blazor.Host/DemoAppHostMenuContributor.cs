using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Account.Localization;

namespace DemoApp.Blazor.Host
{
    public class DemoAppHostMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public DemoAppHostMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        /// <summary>
        /// 侧边栏菜单（主菜单）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.Items.Insert(0,
                new ApplicationMenuItem("Index", displayName: "Index", "/", icon: "fa fa-home"));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 管理账号下的菜单（右上角用户名的下拉菜单）
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var accountStringLocalizer = context.GetLocalizer<AccountResource>();

            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

            context.Menu.AddItem(new ApplicationMenuItem(
                "Account.Manage",
                accountStringLocalizer["MyAccount"],
                $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}",
                icon: "fa fa-cog",
                order: 1000,
                null).RequireAuthenticated());

            return Task.CompletedTask;
        }
    }
}